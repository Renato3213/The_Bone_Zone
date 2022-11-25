using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    public enum State { Working, HavingFun, Resting, Idle }
    public float happiness, energy;
    public NavMeshAgent agent;
    public bool isWorking;
    private void Awake()
    {
        UnitSelection.Instance.unitList.Add(this.gameObject);
        GameManager.instance.listas.esqueletosLivres.Add(this.gameObject);
        GameManager.instance.listas.listaEsqueletos.Add(this.gameObject);
        happiness = 100f;
        energy = 100f;
    }

    private void OnDestroy()
    {
        UnitSelection.Instance.unitList.Remove(this.gameObject);
    }

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
        else
        {
            ProcurarTrabalho();
        }

    }

    void ProcurarTrabalho()
    {
        Debug.Log("uepa");
        if (ControlaListas.instance.fazendasLivres[0] != null)
        {
            Fazendas fazenda = ControlaListas.instance.fazendasLivres[0];
            agent.destination = fazenda.entrada.position;
        }
    }

}
