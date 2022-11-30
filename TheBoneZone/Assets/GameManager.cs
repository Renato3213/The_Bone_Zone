using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float vidas = 100;
    public float Calcio = 0;
    public float Infamia = 0;
    public bool onCenter;
    public bool building;
    public bool isMouseOverInterface;
    public int maxSkeletons;

    public float invasionCountdown;

    public GameObject vazio;

    public GameObject activeInterface;

    public List<GameObject> enemies = new List<GameObject>();
    [SerializeField] Text vidasTxt, infamiaTxt;
    [SerializeField] Text moedasTxt;
    [SerializeField] Text quantiaEsqueletos;

    public ControlaListas listas;
    public GameObject deposit;

    public Image hpImage;
    public Image infamyImage;

    WaveManager waveManager;

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

    public bool mouseOverObject = false;
    void Awake()
    {
        invasionCountdown = 30f;
        instance = this;
        listas = GetComponent<ControlaListas>();
        waveManager = GetComponentInChildren<WaveManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UpdateActiveInterface(vazio);
        } 
    }
    public void AtualizaVidas(float dano)
    {
        vidas -= dano;
        vidasTxt.text = vidas.ToString();
        hpImage.fillAmount = vidas / 100f;
    }

    public void AtualizaCalcio(float qnt)
    {
        Calcio += qnt;
        moedasTxt.text = Calcio.ToString();
    }

    public void UpdateInfamy(float amount)
    {
        Infamia += amount;
        infamiaTxt.text = Infamia.ToString();
        infamyImage.fillAmount = Infamia / 100f;

        invasionCountdown = ((30 * (100 - Infamia)) / 100f) < 1? 1 : ((30 * (100 - Infamia)) / 100f);
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
