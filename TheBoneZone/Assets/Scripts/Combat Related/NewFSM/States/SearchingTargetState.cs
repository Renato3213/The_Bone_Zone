using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingTargetState : IUnitState
{
    CombatUnit unit;
    
    public SearchingTargetState(CombatUnit unit)
    {
        this.unit = unit;
    }

    public void OnUpdate() 
    {
        if (unit.targetsList.Count > 0)
        {
            unit.currentTarget = unit.targetsList[0];
            unit.targetsList.RemoveAt(0);
        }

        else
        {
            unit.currentTarget = PickClosestOpositeUnit();
        }
    }

    CombatUnit PickClosestOpositeUnit()
    {
        CombatUnit closestOpositeUnit = null;
        float closestDistance = Mathf.Infinity;

        foreach (CombatUnit opositeUnit in unit.OpositeTeam)
        {
            float newDistance = Vector3.Distance(opositeUnit.transform.position, unit.transform.position);

            if (newDistance < closestDistance)
            {
                closestDistance = newDistance;
                closestOpositeUnit = opositeUnit;
            }

        }

        return closestOpositeUnit;
    }
    public void OnEnter() { }
    public void OnExit() { }
}
