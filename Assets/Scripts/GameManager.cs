using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject canvas; // canvas do jogo
    public GameObject palavraOcultaPrefab; // prefab da palavra oculta
    public PalavraOcultavel palavraOculta; // palavra oculta a ser descoberta
    public string[] palavrasOcultas = new string[] { "cidade", "floresta", "bola", "escola", "pilha", "computador", "interruptor" }; // palavras do jogo
    public AudioSource corretaResposta;
    public AudioSource respostaErrada;
    public int numTentativas = 0;
    public int maxNumTentativas = 10;

    // Start is called before the first frame update
    void Start()
    {
        numTentativas = 0;
        palavraOculta = Instantiate(palavraOcultaPrefab).GetComponent<PalavraOcultavel>();
        palavraOculta.name = "PalavraOculta";
        palavraOculta.transform.SetParent(canvas.transform);
        palavraOculta.transform.localPosition = new Vector3(0, 0, transform.position.z);

        int numeroAleatorio = UnityEngine.Random.Range(0, palavrasOcultas.Length);
        palavraOculta.SetPalavra(palavrasOcultas[numeroAleatorio]);
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    // Método para verificar o input do teclado
    void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            char letraTeclada = Input.inputString.ToCharArray()[0];
            int letraTecladaComoInt = System.Convert.ToInt32(letraTeclada);

            if (letraTecladaComoInt >= 97 && letraTecladaComoInt <= 122)
            {
                numTentativas++;

                if (numTentativas >= maxNumTentativas)
                {
                    SceneManager.LoadScene("DefeatScene");
                }

                for (int i = 0; i <= palavraOculta.palavra.Length; i++)
                {
                    if (palavraOculta.palavra[i] == char.ToUpper(letraTeclada))
                    {
                        palavraOculta.letras[i].Revelar();
                    }
                }

                if (palavraOculta.letras.All(letra => !letra.oculta))
                {
                    SceneManager.LoadScene("VictoryScene");
                }
            }
        }
    }
}
