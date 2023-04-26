using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    public enum State { Working, HavingFun, Resting, Idle, Walking }
    public float happiness, energy;
    public NavMeshAgent agent;
    public GameObject spawningCircle;


    #region flyweight
    public SkeletonState idleState = new IdleState();
    public SkeletonState farmingState = new FarmingState();
    public SkeletonState buildingState = new BuildingState();
    public SkeletonState walkingState = new WalkingState();
    public SkeletonState spawningState = new SpawningState();
    public AnimationClip[] spawnAnimations;
    public float buildingSpeed;
    #endregion


    public SkeletonState currentState;
    public UnderConstruction buildingTarget;
    public bool doingTask;

    public Animator myAnimator;
    public bool walking = false;

    private void Awake()
    {
        UnitSelection.Instance.unitList.Add(this);
        GameManager.instance.listas.esqueletosLivres.Add(this.gameObject);
        GameManager.instance.listas.listaEsqueletos.Add(this.gameObject);
        happiness = 100f;
        energy = 100f;

    }
    void Update()
    {
        CheckWalking();

        currentState.DoState(this);
    }

    public void MoveTo(Vector3 position)
    {
        agent.destination = position;
    }
    public void CheckWalking()
    {
        if (!agent.enabled) return;
        if(walking == false && agent.hasPath)
        {
            ChangeAnimationState("Walk");
            walking = true;
            if(!doingTask) currentState = walkingState;
        }
        if (agent.pathPending) return;

        if (agent.remainingDistance > agent.stoppingDistance) return;

        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
        {
            walking = false;
        }
    }

    private void OnDestroy()
    {
        UnitSelection.Instance.unitList.Remove(this);
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

    public void ChangeAnimationState(string State)
    {
        myAnimator.StopPlayback();
        myAnimator.Play(State);
    }

}
