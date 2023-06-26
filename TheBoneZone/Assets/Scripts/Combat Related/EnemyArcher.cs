using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : CombatUnit
{
    private void Awake()
    {
        Initialize();
        baseRadius = agent.radius;
        CombatStartObserver.instance.unitList.Add(this);
        CombatManager.instance.redTeam.Add(this);
        this.OpositeTeam = CombatManager.instance.blueTeam;
    }

    public override void TakeDamage(int amount)
    {
        this.health -= amount;

        if (health <= 0) Die();
    }

    public override void Die()
    {
        CombatStartObserver.instance.unitList.Remove(this);
        CombatManager.instance.redTeam.Remove(this);
        this.gameObject.SetActive(false);
        Destroy(this.gameObject, 2f);
    }


    public void NotifyStart()
    {

    }

    private void OnDestroy()
    {
        CombatStartObserver.instance.unitList.Remove(this);
        CombatManager.instance.redTeam.Remove(this);
    }
}

