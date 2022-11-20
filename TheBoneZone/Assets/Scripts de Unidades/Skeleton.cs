using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    public enum State {Working, HavingFun, Resting, Idle}
    public float happiness, energy;
    public NavMeshAgent agent;
    public Transform alvo;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        GameManager.instance.listas.esqueletosLivres.Add(this.gameObject);
        GameManager.instance.listas.listaEsqueletos.Add(this.gameObject);
        happiness = 50f;
        energy = 50f;
        agent.destination = new Vector3(transform.position.x -0.1f, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if(agent.remainingDistance <= 0.05f)
        {
            agent.isStopped = true;
        }

    }

    public void GoRest()
    {
       alvo =  GameManager.instance.listas.casasLivres[0].transform;
       agent.destination = alvo.position;
    }

    public void GoHaveFun()
    {
        alvo = GameManager.instance.listas.pubsLivres[0].transform;
        agent.destination = alvo.position;
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform == alvo)
        {
            Debug.Log("chegou");
            gameObject.SetActive(false);
        }
    }
}
