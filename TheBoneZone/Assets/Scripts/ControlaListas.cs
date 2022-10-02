using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaListas : MonoBehaviour
{
    public static ControlaListas instance;
    public List<GameObject> listaEsqueletos = new List<GameObject>();
    public List<GameObject> listaTrabalhando = new List<GameObject>();
    public List<GameObject> listaCasas = new List<GameObject>();
    public List<GameObject> listaDojos = new List<GameObject>();
    public List<GameObject> listaFazendas = new List<GameObject>();
    public List<GameObject> listaBibliotecas = new List<GameObject>();
    public List<GameObject> listaBares = new List<GameObject>();
    

    
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
