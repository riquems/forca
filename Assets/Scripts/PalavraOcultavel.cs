using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// Classe que representa uma palavra ocultavel e suas letras
public class PalavraOcultavel : MonoBehaviour
{
    public GameObject letraPrefab; // prefab das letras

    public string palavra; // palavra ocultada
    public const int tamanhoDaLetra = 65; // tamanho da letra
    public List<Letra> letras = new List<Letra>(); // lista de letras que compõem a palavra

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetPalavra(string palavra)
    {
        // Limpa a lista de letras
        letras.Clear();

        // Inicializa a palavra
        this.palavra = palavra.ToUpper();

        // Configura o tamanho da palavra no canvas
        int width = this.palavra.Length * tamanhoDaLetra;
        int height = 100;

        GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

        // Para cada letra da palavra, instanciá-la e configurá-la
        for (int i = 0; i < this.palavra.Length; i++)
        {
            Letra letra = Instantiate(letraPrefab).GetComponent<Letra>();
            letra.transform.SetParent(this.transform);
            letra.name = "Letra" + i;
            letra.SetLetra(this.palavra[i]);

            // Calcula e seta a nova posição
            letra.transform.localPosition = new Vector3((i * tamanhoDaLetra) - (width / 2) + (tamanhoDaLetra / 2), 0, transform.position.z);
            
            // Adiciona a letra na lista
            this.letras.Add(letra);
        }
    }

    public char RevelarLetraAleatoria()
    {
        List<Letra> letrasOcultas = this.letras.Where(letra => letra.oculta).ToList();

        int posicaoLetra = UnityEngine.Random.Range(0, letrasOcultas.Count);

        char letra = letrasOcultas[posicaoLetra].letra;

        for (int i = 0; i < this.palavra.Length; i++)
        {
            if (this.palavra[i] == letra)
            {
                this.letras[i].Revelar();
            }
        }

        return letra;
    }
}
