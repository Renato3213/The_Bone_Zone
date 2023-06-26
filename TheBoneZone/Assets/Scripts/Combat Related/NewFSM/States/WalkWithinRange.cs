using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WalkWithinRange : IUnitState
{
    CombatUnit unit;

    Vector3 lastPosition = Vector3.zero;
    float TimeStuck;
    public WalkWithinRange(CombatUnit unit)
    {
        this.unit = unit;
    }

    public void OnUpdate()
    {
        if (Vector3.Distance(unit.transform.position, lastPosition) <= 0f)
            TimeStuck += Time.deltaTime;

        lastPosition = unit.transform.position;

        unit.agent.destination = unit.currentTarget.transform.position;
    }

    public void OnEnter() 
    {
        TimeStuck = 0f;
        unit.agent.isStopped = false;

        if (unit.animator != null)
        {
            unit.animator.Play("Walk");

        }
    }

    public void OnExit() 
    {
        unit.agent.isStopped = true;
        //if (unit.animator != null)
        //{
        //    unit.animator.Play("Idle");

        //}
    }
}
