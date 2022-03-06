using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public int maxNumTentativas = 10;
    public int numTentativas = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartGameButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnCreditosButtonPressed()
    {
        SceneManager.LoadScene("CreditosScene");
    }
}
