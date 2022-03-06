using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictorySceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayAgainButtonPressed()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
