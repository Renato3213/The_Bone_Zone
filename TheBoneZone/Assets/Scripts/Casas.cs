using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casas : MonoBehaviour
{
    public enum Nivel{ nivel1, nivel2, nivel3, nivel4, nivel5};
    public GameObject[] aparencia;
    public bool possuiEsqueletos;
    public int quantidadeEsqueletos;
    public int limiteEsqueletos;
    
    
    void Start()
    {
        //ControlaListas.instance.listaCasas.Add(this.gameObject);
    }

    
    void Update()
    {
        
    }
}
