using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IUnitState
{
    CombatUnit unit;
    AttackBehaviours attackBehavirour;
    public AttackState(CombatUnit unit, AttackBehaviours attackBehavirour)
    {
        this.unit = unit;
        this.attackBehavirour = attackBehavirour;
    }
    public void OnEnter()
    {
        unit.StartCoroutine(Attack());
    }

    public void OnExit()
    {
        unit.StopCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(unit.atkSpeed);

        attackBehavirour.Attack(unit, unit.currentTarget);

        unit.StartCoroutine(Attack());
    }


    public void OnUpdate() { }

}
