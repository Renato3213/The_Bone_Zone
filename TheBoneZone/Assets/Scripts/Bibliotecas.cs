using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bibliotecas : MonoBehaviour
{
    public enum Nivel{ nivel1, nivel2, nivel3, nivel4, nivel5};
    public GameObject[] aparencia;
    public bool possuiEsqueletos;
    public int quantidadeEsqueletos;
    public int limiteEsqueletos;
    
    // Start is called before the first frame update
    void Start()
    {
        ControlaListas.instance.listaBibliotecas.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
