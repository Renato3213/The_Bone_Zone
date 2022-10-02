using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bares : MonoBehaviour
{
    public enum Nivel{ nivel1, nivel2, nivel3, nivel4, nivel5};
    public GameObject[] aparencia;
    public bool possuiEsqueletos;
    public int quantidadeEsqueletos;
    public int limiteEsqueletos = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        ControlaListas.instance.listaBares.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
