using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [Header("Status")]
    [Space]
    public float energy;
    public float tirednessCoefficient;
    public float efficiency = 1f;
    public float goldPocket;
    public SkeletonFlyweight myStats;

    [Header("Spawning")]
    [Space]
    public GameObject spawningCircle;


    #region State Related

    public SkeletonState currentState;
    public UnderConstruction buildingTarget;
    public FarmingSpot farmingSpot;
    public Fazendas grinderTarget;
    public Bares pubTarget;

    #endregion

    #region Hide In Inspector

    [HideInInspector]
    public bool walking = false;
    [HideInInspector]
    public bool doingTask;
    [HideInInspector]
    public bool stateInitialized;
    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public float amountInBag;
    [HideInInspector]
    public Animator myAnimator;

    #endregion

    private void Awake()
    {
        GameManager.instance.resourceManager.amountToPay += myStats.minimumWage;
        //UnitSelection.Instance.unitList.Add(this);
        //UnitSelection.Instance.Deselect(this);
        //GameManager.instance.listas.esqueletosLivres.Add(this.gameObject);
        //GameManager.instance.listas.listaEsqueletos.Add(this.gameObject);
        stateInitialized = false;
        energy = 1f;
        tirednessCoefficient = 0.5f;

    }
    void Update()
    {
        CheckWalking();

        currentState.DoState(this);
    }

    public void ChangeState(SkeletonState state)
    {
        stateInitialized = false;
        currentState = state;
    }
     
    public void MoveTo(Vector3 position)
    {
        agent.destination = position;
    }
    public void CheckWalking()
    {
        if (!agent.enabled) return;
        //if (doingTask) return;
        if (walking == false && agent.hasPath)
        {
            ChangeAnimationState("Walk");
            walking = true;
            if (!doingTask) ChangeState(myStats.walkingState);
        }
        if (agent.pathPending) return;

        if (agent.remainingDistance > agent.stoppingDistance) return;

        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
        {
            walking = false;
        }
    }


    public void UpdateEfficiency()
    {
        efficiency = myStats.happinessCoefficient + tirednessCoefficient;
    }

    public void ResetSkeleton()
    {
        StopAllCoroutines();
        walking = false;
        ChangeState(myStats.idleState);
        ChangeAnimationState("Idle");
        agent.enabled = true;
        agent.isStopped = false;
        doingTask = false;


        buildingTarget = null;

        farmingSpot?.Desocupar();
        farmingSpot = null;

        grinderTarget = null;
        pubTarget = null;
    }

    public void ChangeAnimationState(string State)
    {
        myAnimator.StopPlayback();
        myAnimator.Play(State);
        myAnimator.speed = tirednessCoefficient * 2;
    }
    private void OnDestroy()
    {
        UnitSelection.Instance.unitList.Remove(this);
    }

}
