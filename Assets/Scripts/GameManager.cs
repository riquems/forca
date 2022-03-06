using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject canvas; // canvas do jogo
    public GameObject palavraOcultaPrefab; // prefab da palavra oculta
    public static PalavraOcultavel palavraOculta; // palavra oculta a ser descoberta
    public AudioSource gameMusic; // música do jogo (muito boa)
    public AudioSource corretaResposta; // audio para tocar quando o jogador acertar uma letra
    public AudioSource respostaErrada; // audio para tocar quando o jogador errar uma letra
    public Number numeroDeTentativas; // número de tentativas atual
    public Number numeroMaximoDeTentativas; // número máximo de tentativas para descobrir a palavra
    public Number pontuacao; // pontuação do jogador
    public GameObject dicasButton; // número de dicas para o jogador
    public int numeroDeDicas; // número de dicas para o jogador
    public GameObject letrasJaTentadas; // letras já tentadas pelo jogador

    void Start()
    {
        // Inicializa game objects de números na tela
        numeroDeTentativas = GameObject.Find("NumeroDeTentativas").GetComponent<Number>().Init();
        numeroMaximoDeTentativas = GameObject.Find("NumeroMaximoDeTentativas").GetComponent<Number>().Init();
        pontuacao = GameObject.Find("Pontuacao").GetComponent<Number>().Init();

        // Configura seus valores iniciais
        numeroDeTentativas.SetNumber(0);
        pontuacao.SetNumber(PlayerPrefs.GetInt("score"));
        letrasJaTentadas.GetComponent<Text>().text = string.Empty;

        // Cria a palavra, que por sua vez se encarrega de criar suas letras assim que a função SetPalavra é chamada
        palavraOculta = Instantiate(palavraOcultaPrefab).GetComponent<PalavraOcultavel>();
        palavraOculta.name = "PalavraOculta";
        palavraOculta.transform.SetParent(canvas.transform);
        palavraOculta.transform.localPosition = new Vector3(0, 0, transform.position.z);

        // Pegar uma palavra aleatóriamente
        string palavra = PegarPalavraAleatoriaDoArquivo();

        // Configura o número máximo de tentativas de acordo com o tamanho da palavra
        numeroMaximoDeTentativas.SetNumber(palavra.Length + 5);

        // Configura o número de dicas de acordo com uma porcentagem do tamanho da palavra
        numeroDeDicas = Convert.ToInt32(palavra.Length * 0.3);
        AtualizarNumeroDeDicas();

        // Configura a palavra, encadeando um processo em que suas letras também são criadas
        palavraOculta.SetPalavra(palavra);

        // Para a música de intro
        GameObject.FindGameObjectWithTag("IntroMusic")?.GetComponent<GameMusic>()?.StopMusic();

        // Toca música se não exister tocando
        if (!gameMusic.isPlaying)
        {
            gameMusic.Play();
        }
    }

    public void OnDicasButtonPressed()
    {
        if (numeroDeDicas <= 0) return;

        numeroDeDicas--;
        AtualizarNumeroDeDicas();

        char letraRevelada = palavraOculta.RevelarLetraAleatoria();
        letrasJaTentadas.GetComponent<Text>().text += (letraRevelada.ToString().ToUpper() + " ");

        corretaResposta.Play();
        CheckVictory();
    }

    private void AtualizarNumeroDeDicas()
    {
        Text dicasText = dicasButton.GetComponentInChildren<Text>();
        dicasText.text = $"Dicas ({numeroDeDicas})";
    }

    void Update()
    {
        CheckInput();
    }

    // Método para verificar o input do teclado
    void CheckInput()
    {
        if (!Input.anyKeyDown || string.IsNullOrEmpty(Input.inputString))
            return;
        
        char letraTeclada = Input.inputString.ToCharArray()[0];
        int letraTecladaComoInt = Convert.ToInt32(letraTeclada);

        if (letraTecladaComoInt < 67 || letraTecladaComoInt > 122)
            return;

        if (letrasJaTentadas.GetComponent<Text>().text.Contains(char.ToUpper(letraTeclada)))
        {
            respostaErrada.Play();
            return;
        }

        if (palavraOculta.letras.Any(letra => letra.letra == char.ToUpper(letraTeclada)))
        {
            corretaResposta.Play();
        }
        else
        {
            respostaErrada.Play();
            numeroDeTentativas++;
        }

        letrasJaTentadas.GetComponent<Text>().text += (letraTeclada.ToString().ToUpper() + " ");

        // Verifica se perdeu
        CheckDefeat();

        // Atualiza as letras
        for (int i = 0; i < palavraOculta.palavra.Length; i++)
        {
            if (palavraOculta.palavra[i] == char.ToUpper(letraTeclada))
            {
                palavraOculta.letras[i].Revelar();
            }
        }

        // Verifica se ganhou
        CheckVictory();
    }

    void CheckDefeat()
    {
        if (numeroDeTentativas >= numeroMaximoDeTentativas)
        {
            SceneManager.LoadScene("DefeatScene");
        }
    }

    void CheckVictory()
    {
        if (palavraOculta.letras.All(letra => !letra.oculta))
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1);
            SceneManager.LoadScene("VictoryScene");
        }
    }

    string PegarPalavraAleatoriaDoArquivo()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("palavras");
        string[] palavras = textAsset.text.Split(',').Select(palavra => palavra.Trim()).ToArray();
        int numeroAleatorio = UnityEngine.Random.Range(0, palavras.Length);
        return palavras[numeroAleatorio];
    }
}
