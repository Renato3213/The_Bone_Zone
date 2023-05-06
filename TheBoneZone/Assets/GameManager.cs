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
    public ControlaListas ListManager;


    [Header("Other")]

    public float Calcio = 0;
    public bool building;
    public bool isMouseOverInterface;
    public int maxSkeletons;

    //public float invasionCountdown;

    public StructureFlyweight structureStats { get; }

    [HideInInspector]
    public GameObject vazio;
    public GameObject pauseMenu;
    Camera myCam;

    public GameObject activeInterface;
    
    [SerializeField] Text moedasTxt;
    [SerializeField] Text quantiaEsqueletos;

    public GameObject deposit;

    public bool isPause = false;

    public LayerMask ground;

    public bool isMouseOverObject;
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
        if(Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            UpdateActiveInterface(pauseMenu);
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1f;
            UpdateActiveInterface(vazio);
        }
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
}
