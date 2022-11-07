using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fazendas : MonoBehaviour
{
    public int quantidadeEsqueletos = 0;
    public int limiteEsqueletos = 5;
    public float producao = 20f;
    public float tempo = 0;
   
    public List<GameObject> trabalhandoAqui = new List<GameObject> ();


    void Awake()
    {
        ControlaListas.instance.listaFazendas.Add(this.gameObject);
    }

    
    void FixedUpdate()
    {
        if(trabalhandoAqui.Count > 0)
        {
            tempo += Time.fixedDeltaTime;
            if(tempo > 1f)
            {
                GameManager.instance.AtualizaCalcio(producao * quantidadeEsqueletos);
                tempo = 0;
            }
        }
    }

    [ContextMenu("uepa")]
    public void ChamarEsqueleto()
    {
        if(GameManager.instance.listas.esqueletosLivres.Count > 0)
        {
            NavMeshAgent agent = GameManager.instance.listas.esqueletosLivres[quantidadeEsqueletos].gameObject.GetComponent<NavMeshAgent>();
            agent.isStopped = false;
            agent.destination = transform.position;
            quantidadeEsqueletos++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider != null)
        {
            if (collision.transform.CompareTag("Esqueleto"))
            {
                NavMeshAgent agent = collision.gameObject.GetComponent<NavMeshAgent>();
                agent.isStopped = true;
                collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
                trabalhandoAqui.Add(collision.gameObject);
            }
        }
    }

    public void LiberarEsqueleto()
    {

    }
}
