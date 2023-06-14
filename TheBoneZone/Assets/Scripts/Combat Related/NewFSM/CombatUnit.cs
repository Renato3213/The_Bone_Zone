using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CombatUnit : MonoBehaviour
{
    public enum AttackType { Melee, Ranged};

    public List<CombatUnit> OpositeTeam = new List<CombatUnit>();

    public List<CombatUnit> targetsList = new List<CombatUnit>();

    [SerializeField]
    UnitStateMachine stateMachine;

    public CombatUnit currentTarget;

    public AttackBehaviours meleeBehaviour;
    public AttackBehaviours rangedBehaviour;

    public IUnitState dormantState;
    public IUnitState searchingState;
    public IUnitState moveWithinRange;
    public IUnitState attack;

    public NavMeshAgent agent;

    public int attackPower;
    public int health;
    public float range;
    public float atkSpeed;
    public AttackType type;

    public TableTile myTile;

    public void Initialize()
    {
        agent = GetComponent<NavMeshAgent>();

        dormantState = new SleepingState(this);
        searchingState = new SearchingTargetState(this);
        moveWithinRange = new WalkWithinRange(this);

        if (type == AttackType.Melee)
            attack = new AttackState(this, meleeBehaviour);


        if (type == AttackType.Ranged)
            attack = new AttackState(this, rangedBehaviour);


        AddT(dormantState, searchingState, HasSimulationStarted());
        AddT(searchingState, moveWithinRange, HasTarget());
        AddT(moveWithinRange, attack, ReachedTarget());
        AddT(attack, moveWithinRange, TargetGotOutOfRange());
        AddT(attack, searchingState, TargetIsGone());
        AddT(moveWithinRange, searchingState, TargetIsGone());
        AddT(searchingState, dormantState, TargetIsGone());

        //no mode adversaries
        AddT(searchingState, dormantState, NoMoreAdversaries());
        AddT(moveWithinRange, dormantState, NoMoreAdversaries());
        AddT(attack, dormantState, NoMoreAdversaries());

        void AddT(IUnitState from, IUnitState to, Func<bool> condiditon)
        {
            stateMachine.AddTransition(from, to, condiditon);
        }

        stateMachine.SetState(dormantState);

        Func<bool> HasTarget() => () => currentTarget != null;
        Func<bool> ReachedTarget() => () => currentTarget != null &&
                                              Vector3.Distance(transform.position, currentTarget.transform.position) < range;
        Func<bool> TargetGotOutOfRange() => () => currentTarget != null &&
                                              Vector3.Distance(transform.position, currentTarget.transform.position) > range;
        Func<bool> TargetIsGone() => () => !OpositeTeam.Contains(currentTarget);
        Func<bool> NoMoreAdversaries() => () => OpositeTeam.Count == 0;
        Func<bool> HasSimulationStarted() => () => CombatManager.instance.gameStarted;
    }

    private void FixedUpdate()
    {
        stateMachine.OnUpdate();
    }

    public virtual void TakeDamage(int amount)
    {

    }

    public virtual void Die()
    {
 
    }
}
