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
        GameManager.instance.UpdateInfamy(1);
        happiness = 100f;
        energy = 100f;
    }

    private void OnDestroy()
    {
        UnitSelection.Instance.unitList.Remove(this.gameObject);
    }
    [ContextMenu("descansa")]
    public void Recover()
    {
        if (happiness > 0 && energy > 0)
        {
            ProcurarTrabalho();
        }
        else if (energy == 0)
        {
            if (GameManager.instance.listas.casasLivres.Count == 0) return;

            else
            {
                Casas casa = GameManager.instance.listas.casasLivres[0];
                agent.destination = casa.entrada.position;
            }


        }
        else if (happiness == 0)
        {

            if (GameManager.instance.listas.pubsLivres.Count == 0) return;
            
            else
            {
                Bares bar = GameManager.instance.listas.pubsLivres[0];
                agent.destination = bar.entrada.position;
            }
        }

    }
    [ContextMenu("trabalho")]
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
