using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float Calcio = 0;
    public bool onCenter;
    public bool building;
    public bool isMouseOverInterface;
    public int maxSkeletons;

    public float invasionCountdown;

    public GameObject vazio;
    public GameObject pauseMenu;
    Camera myCam;

    public GameObject activeInterface;
    
    [SerializeField] Text moedasTxt;
    [SerializeField] Text quantiaEsqueletos;

    public ControlaListas listas;
    public GameObject deposit;

    public Image hpImage;

    public bool isPause = false;

    public bool mouseOverObject = false;
    void Awake()
    {
        myCam = Camera.main;
        invasionCountdown = 30f;
        instance = this;
        listas = GetComponent<ControlaListas>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
            if (Physics.Raycast(ray, out hit) && !isOverUI)
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

    public void AtualizaCalcio(float qnt)
    {
        Calcio = (int)(Calcio + qnt);
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

    public void SetPause(bool p)
    {
        isPause = p;
        if (isPause)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
