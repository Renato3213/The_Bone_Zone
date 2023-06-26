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
    public List<Casas> housesList = new List<Casas>();
    public List<Fazendas> grindersList = new List<Fazendas>();
    public List<Bares> pubsList = new List<Bares>();
    public List<UnderConstruction> beingConstructedList = new List<UnderConstruction>();
    public List<FarmingSpot> farmingSpotList = new List<FarmingSpot>();

    public List<Skeleton> skeletonsGrinding = new List<Skeleton>();

    public List<LevelNode> levels = new List<LevelNode>();
    private void Start()
    {
        instance = this;
    }



}
