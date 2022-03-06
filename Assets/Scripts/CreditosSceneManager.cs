using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Cena de créditos
public class CreditosSceneManager : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("IntroMusic").GetComponent<GameMusic>().PlayMusic();
    }

    void Update()
    {
        
    }

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene("StartScene");
    }
}
