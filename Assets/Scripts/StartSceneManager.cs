using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Cena inicial
public class StartSceneManager : MonoBehaviour
{
    void Start()
    {
        // Reinicializa o jogo
        PlayerPrefs.SetInt("score", 0);
        GameObject.FindGameObjectWithTag("IntroMusic").GetComponent<GameMusic>().PlayMusic();
    }

    void Update()
    {
        
    }

    public void OnStartGameButtonPressed()
    {
        // Inicia um novo jogo
        SceneManager.LoadScene("GameScene");
    }

    public void OnCreditosButtonPressed()
    {
        SceneManager.LoadScene("CreditosScene");
    }
}
