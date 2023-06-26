using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Manager References")]
    [Space]
    public ResourceManager resourceManager;
    public InterfaceManager interfaceManager;
    public ControlaListas listManager;


    [Header("Other")]

    public float Calcio = 0;
    public bool building;
    public bool isMouseOverInterface;
    public int maxSkeletons;

    //public float invasionCountdown;

    public StructureFlyweight structureStats { get; }
    public SkeletonFlyweight skeletonStats;

    [SerializeField]
    Camera myCam;
    [HideInInspector]
    public GameObject vazio;
    public GameObject pauseMenu;

    public GameObject activeInterface;

    [SerializeField] Text moedasTxt;
    [SerializeField] Text quantiaEsqueletos;

    public GameObject deposit;

    public bool isPause = false;

    public LayerMask ground;

    public bool isMouseOverObject;


    [SerializeField]
    GameObject housePrefab, pubPrefab, farmingSpotPrefab, grinderPrefab;


    void Awake()
    {
        myCam = Camera.main;
        instance = this;
    }

    private void Update()
    {
        isMouseOverObject = IsMouseOverObject();
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && !IsMouseOverUI())
            {
                if (hit.collider.CompareTag("ground"))
                {
                    UpdateActiveInterface(vazio);
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public bool IsMouseOverUI()
    {
        return UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
    }
    public bool IsMouseOverObject()
    {
        RaycastHit hit;
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("ground"))
            {
                return false;
            }
            else return true;
        }
        return false;
    }

    public void Pause()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            UpdateActiveInterface(pauseMenu);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
            UpdateActiveInterface(vazio);
        }
    }

    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void UpdateActiveInterface(GameObject newInterface)
    {
        if (activeInterface != null) activeInterface.gameObject.GetComponent<Canvas>().enabled = false;

        activeInterface = newInterface;
        activeInterface.gameObject.GetComponent<Canvas>().enabled = true;
    }
    public void UpdateCalcium(float amount)
    {
        resourceManager.UpdateCalcium(amount);
    }

    public void UpdateGold(float amount)
    {
        resourceManager.UpdateGold(amount);
    }

    public void UpdateSkeletonCount()
    {
        resourceManager.UpdateSkeletonCount();
    }


    public void LoadStructures(SceneData data)
    {
        foreach(HouseData hData in data.houses)
        {
            Instantiate(housePrefab, hData.position, Quaternion.Euler(hData.rotation));
        }

        foreach (PubData pData in data.pubs)
        {
            GameObject pub = Instantiate(pubPrefab, pData.position, Quaternion.Euler(pData.rotation));
            Bares pubScript = pub.GetComponent<Bares>();

        }

        foreach (FarmingSpotData fsData in data.farmingSpots)
        {
            GameObject fs = Instantiate(farmingSpotPrefab, fsData.position, Quaternion.Euler(fsData.rotation));
            FarmingSpot fsScript = fs.GetComponent<FarmingSpot>();

        }

        foreach (GrinderData gData in data.grinders)
        {
            GameObject grinder = Instantiate(grinderPrefab, gData.position, Quaternion.Euler(gData.rotation));
            Fazendas grinderClass = grinder.GetComponentInChildren<Fazendas>();

            grinderClass.bonesStored = gData.bonesStored;
            grinderClass.workingHere = gData.workingHere;
        }
    }


    public ResourceData GetResources()
    {
        ResourceData resourceData = new ResourceData();

        
        resourceData.calcium = (int)resourceManager.resourceFlyweight.calcium;
        resourceData.gold = (int)resourceManager.resourceFlyweight.gold;

        return resourceData;
    }
    public void SetResources(SceneData data)
    {
        resourceManager.resourceFlyweight.calcium = 0;
        resourceManager.resourceFlyweight.gold = 0;

        resourceManager.UpdateCalcium(data.resourceData.calcium);
        resourceManager.UpdateGold(data.resourceData.gold);
    }

}
