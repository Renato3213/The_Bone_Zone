using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class Skeleton : MonoBehaviour, IDataPersistance
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

    //public SkeletonState currentState;
    public UnderConstruction buildingTarget;
    public FarmingSpot farmingSpot;
    public int farmingSpotID;
    public int grinderID;
    public int pubID;
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

    public GameObject buildingParticle;
    public ParticleSystem buildingPSystem;

    [SerializeField]
    SkeletonStateMachine stateMachine;

    public ISkeletonState buildingState;
    public ISkeletonState deliveringState;
    public ISkeletonState farmingState;
    public ISkeletonState grindingState;
    public ISkeletonState idleState;
    public ISkeletonState restingState;
    public ISkeletonState spawningState;
    public ISkeletonState walkingState;

    public bool spawned;

    public bool isFarming;
    public bool isDelivering;
    public bool isGrinding;
    public bool isBuilding;
    public bool isResting;

    public bool reseted;

    public Vector3 agentDestination;

    void Awake()
    {
        myStats = GameManager.instance.skeletonStats;
        agent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponentInChildren<Animator>();
        spawningCircle = transform.GetChild(2).gameObject;
        stateMachine = GetComponent<SkeletonStateMachine>();


        UnitSelection.Instance.unitList.Add(this);
        UnitSelection.Instance.Deselect(this);
        //GameManager.instance.listManager.esqueletosLivres.Add(this.gameObject);
        //GameManager.instance.listManager.listaEsqueletos.Add(this.gameObject);
        stateInitialized = false;
        energy = 1f;
        tirednessCoefficient = 0.5f;

        GameManager.instance.resourceManager.amountToPay += myStats.minimumWage;

        buildingState = new BuildingState();
        deliveringState = new DeliveringState();
        farmingState = new FarmingState();
        grindingState = new GrindingState();
        idleState = new IdleState();
        restingState = new RestingState();
        spawningState = new SpawningState();
        walkingState = new WalkingState();


        //transitions involving idle
        AddT(spawningState, idleState, FinishedSpawning());

        AddT(idleState, walkingState, AgentHasPath());
        AddT(idleState, grindingState, IsGrinding());
        AddT(idleState, farmingState, IsFarming());
        AddT(idleState, buildingState, IsBuilding());

        AddT(restingState, idleState, FinishedResting());

        //transitions involving walking
        AddT(walkingState, idleState, ArrivedAtDestination());
        AddT(walkingState, farmingState, ArrivedToFarm());
        AddT(walkingState, buildingState, ArrivedToBuild());
        AddT(walkingState, grindingState, ArrivedToGrind());
        AddT(walkingState, restingState, ArrivedToRest());


        AddT(farmingState, walkingState, Reseted());
        AddT(deliveringState, walkingState, Reseted());
        AddT(buildingState, walkingState, Reseted());
        AddT(grindingState, idleState, Reseted());

        //other
        AddT(farmingState, deliveringState, BagIsFull());
        //AddT(deliveringState, farmingState, BagIsNotFull());
        AddT(deliveringState, walkingState, ReturnToFarming());
        AddT(buildingState, walkingState, HasMoreToBuild());
        AddT(buildingState, idleState, NoMoreToBuild());

        void AddT(ISkeletonState from, ISkeletonState to, Func<bool> condiditon)
        {
            stateMachine.AddTransition(from, to, condiditon);
        }

        stateMachine.SetState(spawningState);

        Func<bool> FinishedSpawning() => () => spawned == true;

        Func<bool> IsGrinding() => () => isGrinding == true;
        Func<bool> IsFarming() => () => isFarming == true;
        Func<bool> IsBuilding() => () => isBuilding == true;

        Func<bool> AgentHasPath() => () => agent.hasPath == true;
        Func<bool> HasMoreToBuild() => () => agent.hasPath == true && buildingTarget != null && agent.isStopped == false;
        Func<bool> NoMoreToBuild() => () => buildingTarget == null && isBuilding == false;
        Func<bool> ArrivedAtDestination() => () => agent.hasPath == false &&
                                              Vector3.Distance(transform.position, agent.destination) < 0.1f;

        Func<bool> ArrivedToFarm() => () => agent.hasPath == true && isFarming &&
                                            Vector3.Distance(transform.position, agent.destination) < 0.1f;

        Func<bool> ArrivedToBuild() => () => agent.hasPath == true && isBuilding &&
                                            Vector3.Distance(transform.position, agent.destination) < 0.1f;

        Func<bool> ArrivedToGrind() => () => agent.hasPath == true && isGrinding &&
                                            Vector3.Distance(transform.position, agent.destination) < 1.5f;

        Func<bool> ArrivedToRest() => () => agent.hasPath == true && isResting &&
                                            Vector3.Distance(transform.position, agent.destination) < 0.1f;


        Func<bool> Reseted() => () => reseted == true;
        Func<bool> FinishedResting() => () => energy >= 1 && isResting == false;
        Func<bool> BagIsFull() => () => amountInBag >= myStats.maxBagCapacity;
        Func<bool> ReturnToFarming() => () => amountInBag < myStats.maxBagCapacity && isDelivering == false;


    }

    void Start()
    {
        SaveGame.instance.persistentObjects.Add(this);
    }

    void FixedUpdate()
    {
        stateMachine.OnUpdate();
    }

    public void GetTired()
    {
        if (energy == 0)
            return;

        energy -= Time.deltaTime / myStats.workTime < 0 ? 0 : Time.deltaTime / myStats.workTime;

        if (energy <= 0)
        {
            energy = 0;
            tirednessCoefficient = 0.25f;
            UpdateEfficiency();
        }
    }


    

    void Update()
    {
        //CheckWalking();

        //currentState?.DoState(this);
    }

    public void ChangeState(SkeletonState state)
    {
        //stateInitialized = false;
        //currentState = state;
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
            if (!doingTask)
            {
                //ChangeState(myStats.walkingState);
            }
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
        isBuilding = false;
        isDelivering = false;
        isFarming = false;
        isGrinding = false;
        isResting = false;
        reseted = true;

        agent.enabled = true;

        //StopAllCoroutines();
        //walking = false;
        //ChangeState(myStats.idleState);
        //ChangeAnimationState("Idle");
        //agent.isStopped = false;
        //doingTask = false;


        //buildingTarget = null;

        //farmingSpot?.Desocupar();
        //farmingSpot = null;

        //grinderTarget = null;
        //pubTarget = null;
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

    public void SaveData(ref SceneData data)
    {
        data.skeletons.Add(new SkeletonAdapter(this));
    }


    
}
