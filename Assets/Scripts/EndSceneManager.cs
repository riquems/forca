using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Classe utilizada por cenas que representam o final do jogo (ex: VictoryScene e DefeatScene)
public class EndSceneManager : MonoBehaviour
{
    public GameObject palavra; // palavra que foi ou não adivinhada
    public Number pontuacao; // pontuação do jogador

    void Start()
    {
        pontuacao = GameObject.Find("Pontuacao").GetComponent<Number>().Init();

        palavra.GetComponent<Text>().text = GameManager.palavraOculta.palavra;
        pontuacao.SetNumber(PlayerPrefs.GetInt("score"));
        GameObject.FindGameObjectWithTag("IntroMusic").GetComponent<GameMusic>().StopMusic();
    }

    void Update()
    {
        
    }

    public void OnPlayAgainButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnCreditsButtonPressed()
    {
        SceneManager.LoadScene("CreditosScene");
    }

    public void OnQuitButtonPressed()
    {
        // Essa condicional é necessária pois eu quero que o jogo pare quando eu estiver rodando no Unity
        // e que ele feche quando estiver rodando em uma janela
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
