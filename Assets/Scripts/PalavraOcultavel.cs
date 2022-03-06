using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalavraOcultavel : MonoBehaviour
{
    public GameObject letraPrefab;

    public string palavra;
    public const int tamanhoDaLetra = 65;
    public List<Letra> letras = new List<Letra>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetPalavra(string palavra)
    {
        letras.Clear();

        this.palavra = palavra.ToUpper();

        int width = this.palavra.Length * tamanhoDaLetra;
        int height = 100;

        GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

        for (int i = 0; i < this.palavra.Length; i++)
        {
            Letra letra = Instantiate(letraPrefab).GetComponent<Letra>();
            letra.transform.SetParent(this.transform);
            letra.name = "Letra" + i;
            letra.SetLetra(this.palavra[i]);
            letra.transform.localPosition = new Vector3((i * tamanhoDaLetra) - (width / 2) + (tamanhoDaLetra / 2), 0, transform.position.z);
            
            this.letras.Add(letra);
        }
    }
}
