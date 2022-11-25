using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    public enum State { Working, HavingFun, Resting, Idle }
    public float happiness, energy;
    public NavMeshAgent agent;
    public bool isWorking;
    //public GameObject alvo;
    private void Awake()
    {
        UnitSelection.Instance.unitList.Add(this.gameObject);
        //agent = GetComponent<NavMeshAgent>();
        GameManager.instance.listas.esqueletosLivres.Add(this.gameObject);
        GameManager.instance.listas.listaEsqueletos.Add(this.gameObject);
        happiness = 100f;
        energy = 100f;
        //agent.destination = new Vector3(transform.position.x -0.1f, transform.position.y, transform.position.z);
    }

    private void OnDestroy()
    {
        UnitSelection.Instance.unitList.Remove(this.gameObject);
    }

    /*private void FixedUpdate()
    {
        if(agent.remainingDistance <= 0.05f)
        {
            agent.isStopped = true;
        }

    }*/

    public void Recover()
    {
        if (happiness == 0)
        {
            // alvo = GameManager.instance.listas.pubsLivres[0];

            
        }
        else if (energy == 0)
        {
            Casas casa = GameManager.instance.listas.casasLivres[0];

            if (casa != null)
            {
                agent.destination = casa.entrada.position;
            }

        }

        //agent.destination = alvo.position;
    }



}
