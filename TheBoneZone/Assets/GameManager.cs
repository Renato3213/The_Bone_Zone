using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int vidas = 100;
    public int moedas = 100;

    public List<GameObject> enemies = new List<GameObject>();
    [SerializeField] Text vidasTxt;
    [SerializeField] Text moedasTxt;


    public int totalEsqueletos;
    public int esqueletosTrabalhando;
    public int esqueletosPesquisando;
    public int esqueletosDefendendo;
    public float totalCalcio = 0;
    public float totalInfamia = 0;
    public int totalOuro = 0;
    public int quantidadeFarmers;
    public int quantidadeKnights;
    public int quantidadeScouts;
    public int quantidadeCasas;
    public int quantidadeFazendas;
    public int quantidadeDojos;
    public int quantidadeBibliotecas;
    public int quantidadeBares;
    void Awake()
    {
        instance = this;
    }


    public void AtualizaVidas(int dano)
    {
        vidas -= dano;
        vidasTxt.text = vidas.ToString();
    }

    public void AtualizaMoedas(int qnt)
    {
        moedas += qnt;
        moedasTxt.text = moedas.ToString();
    }

}
