using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;

    [SerializeField] SceneLoader sceneLoader;

    public LevelRefference levelReference;

    public Material placeableMaterial, notPlaceableMaterial;

    public List<TableTile> tableTiles= new List<TableTile>();

    public GameObject tableTilesPack;
    public GameObject unitsPack;

    public List<CombatUnit> redTeam = new List<CombatUnit>();
    public List<CombatUnit> blueTeam = new List<CombatUnit>();

    public bool gameStarted;


    void Start()
    {
        instance = this;


        Invoke("Initialize", 0.01f);
    }

    public void StartGame()
    {
        foreach(CombatUnit unit in blueTeam)
        {
            unit.gameObject.GetComponent<NavMeshAgent>().enabled = true;
        }
        gameStarted = true;
    }

    void Initialize()
    {
        tableTilesPack.SetActive(true);
        unitsPack.SetActive(true);
    }

    public void RemoveFromRedTeam(CombatUnit unit)
    {
        redTeam.Remove(unit);
        if(redTeam.Count == 0)
        {
            Conquer();
        }
    }


    [ContextMenu("conquer")]
    public void Conquer()
    {
        PlayerPrefs.SetInt("Conquered", 1);
        sceneLoader.LoadScene("Game");

    }
}
