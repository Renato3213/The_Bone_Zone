using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fazendas : MonoBehaviour
{
    public enum Nivel{ nivel1, nivel2, nivel3};
    public GameObject[] aparencia;
    public bool possuiEsqueletos = false;
    public int quantidadeEsqueletos = 0;
    public int limiteEsqueletos = 3;
    public float producao = 25f;
    public float tempo = 0;
    public float estoqueCalcio = 0;


    void Awake()
    {
        ControlaListas.instance.listaFazendas.Add(this.gameObject);
    }

    
    void Update()
    {
        if(quantidadeEsqueletos > 0)
        {
            possuiEsqueletos = true;
        }
        else{
            possuiEsqueletos = false;
        }

        if(possuiEsqueletos == true)
        {
            tempo += Time.deltaTime;
            if(tempo > 1f)
            {
                estoqueCalcio += producao * quantidadeEsqueletos;
                GameManager.instance.AtualizaCalcio(producao * quantidadeEsqueletos);
                tempo = 0;
            }
        }
    }
}
