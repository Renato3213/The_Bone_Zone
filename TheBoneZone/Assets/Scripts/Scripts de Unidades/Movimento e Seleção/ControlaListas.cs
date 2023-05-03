using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaListas : MonoBehaviour
{
    public static ControlaListas instance;
    public List<GameObject> listaEsqueletos = new List<GameObject>();
    public List<GameObject> listaTrabalhando = new List<GameObject>();
    public List<GameObject> listaCasas = new List<GameObject>();
    public List<GameObject> listaFazendas = new List<GameObject>();
    public List<GameObject> listaPubs = new List<GameObject>();

    public List<GameObject> esqueletosLivres = new List<GameObject>();
    public List<Casas> casasLivres = new List<Casas>();
    public List<Fazendas> grindersList = new List<Fazendas>();
    public List<Bares> pubsLivres = new List<Bares>();
    public List<UnderConstruction> beingConstructedList = new List<UnderConstruction>();
    public List<FarmingSpot> farmingSpotList = new List<FarmingSpot>();



    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
