using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Classe que representa uma letra de uma palavra
public class Letra : MonoBehaviour
{
    public char letra; // letra da palavra

    public bool oculta; // se está oculta ou não
    public string simboloQuandoEstiverOculta = "?"; // símbolo para mostrar quando a letra estiver oculta
    private Text text; // referencia para o texto no jogo

    void Start()
    {
    }

    void Update()
    {

    }

    // Método para atribuir uma letra
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

    // Método para revelar a letra
    public void Revelar()
    {
        this.oculta = false;
        GetComponent<Text>().text = letra.ToString();
    }

    // Método para ocultar a letra
    public void Ocultar()
    {
        this.oculta = true;
        GetComponent<Text>().text = simboloQuandoEstiverOculta;
    }
}
