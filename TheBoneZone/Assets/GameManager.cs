using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int vidas = 100;
    public float Calcio = 0;
    public float Infamia = 0;
    public bool onCenter;
    public bool building;
    public bool isMouseOverInterface;
    public int maxSkeletons;
    public GameObject vazio;

    public GameObject activeInterface;

    public List<GameObject> enemies = new List<GameObject>();
    [SerializeField] Text vidasTxt;
    [SerializeField] Text moedasTxt;
    [SerializeField] Text quantiaEsqueletos;

    public ControlaListas listas;

    public int esqueletosTrabalhando;
    public int esqueletosPesquisando;
    public int esqueletosDefendendo;
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
        listas = GetComponent<ControlaListas>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UpdateActiveInterface(vazio);
        } 
    }
    public void AtualizaVidas(int dano)
    {
        vidas -= dano;
        vidasTxt.text = vidas.ToString();
    }

    public void AtualizaCalcio(float qnt)
    {
        Calcio += qnt;
        moedasTxt.text = Calcio.ToString();
    }

    public void UpdateActiveInterface(GameObject newInterface)
    {
        if (activeInterface != null) activeInterface.gameObject.GetComponent<Canvas>().enabled = false;

        activeInterface = newInterface;
        activeInterface.gameObject.GetComponent<Canvas>().enabled = true;
    }

    public void UpdateSkeletonCount()
    {
        quantiaEsqueletos.text = ": " + listas.listaEsqueletos.Count + "/" + maxSkeletons;
    }
}
