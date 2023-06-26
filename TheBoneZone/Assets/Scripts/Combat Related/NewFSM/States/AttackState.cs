using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IUnitState
{
    CombatUnit unit;
    AttackBehaviours attackBehavirour;

    float atkSpeed= 0f;
    float time;
    public AttackState(CombatUnit unit, AttackBehaviours attackBehavirour)
    {
        this.unit = unit;
        this.attackBehavirour = attackBehavirour;
        atkSpeed = unit.atkSpeed;
    }
    public void OnEnter()
    {
        //unit.StartCoroutine(Attack());
        if(unit.animator!= null)
        {
            unit.animator.Play("Idle");
        }
    }

    public void OnExit()
    {
        //unit.StopCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(unit.atkSpeed);

        attackBehavirour.Attack(unit, unit.currentTarget);

        Debug.Log("aa");
        unit.StartCoroutine(Attack());
    }


    public void OnUpdate() 
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            attackBehavirour.Attack(unit, unit.currentTarget);
            time = atkSpeed;
        }
    }

}
