using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letra : MonoBehaviour
{
    public char letra; // letra da palavra

    public bool oculta; // se est� oculta ou n�o
    public string simboloQuandoEstiverOculta = "?"; // s�mbolo para mostrar quando a letra estiver oculta
    private Text text; // referencia para o texto no jogo

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // M�todo para atribuir uma letra
    public void SetLetra(char letra, bool oculta = true)
    {
        this.letra = letra;
        this.oculta = oculta;

        if (oculta)
        {
            GetComponent<Text>().text = simboloQuandoEstiverOculta;
        }
        else
        {
            GetComponent<Text>().text = letra.ToString();
        }
    }

    // M�todo para revelar a letra
    public void Revelar()
    {
        this.oculta = false;
        GetComponent<Text>().text = letra.ToString();
    }

    // M�todo para ocultar a letra
    public void Ocultar()
    {
        this.oculta = true;
        GetComponent<Text>().text = simboloQuandoEstiverOculta;
    }
}
