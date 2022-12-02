using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject pauseMenu;
    Camera myCam;

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

    public bool isPause = false;

    public bool mouseOverObject = false;
    void Awake()
    {
        myCam = Camera.main;
        invasionCountdown = 30f;
        instance = this;
        listas = GetComponent<ControlaListas>();
        waveManager = GetComponentInChildren<WaveManager>();
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
    public void AtualizaVidas(float dano)
    {
        vidas = Mathf.Abs(vidas - dano);
        UpdateInfamy(dano * 2);
        vidasTxt.text = vidas.ToString();
        hpImage.fillAmount = vidas / 100f;

        if(vidas <= 0)
        {
            SceneManager.LoadScene("TelaDerrota");
        }
    }

    public void AtualizaCalcio(float qnt)
    {
        Calcio = Mathf.Abs(Calcio + qnt);
        moedasTxt.text = Calcio.ToString();
    }

    public void UpdateInfamy(float amount)
    {
        Infamia = Mathf.Abs(Infamia + amount);
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
