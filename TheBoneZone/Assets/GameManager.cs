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
