using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CombatUnit, ICombatObserver
{

    private void Awake()
    {
        Initialize();
        CombatStartObserver.instance.unitList.Add(this);
        CombatManager.instance.redTeam.Add(this);
        this.OpositeTeam = CombatManager.instance.blueTeam;
    }


    public override void TakeDamage(int amount)
    {
        this.health -= amount;
        if (this.health <= 0) Die();
    }

    public override void Die()
    {
        CombatStartObserver.instance.unitList.Remove(this);
        CombatManager.instance.RemoveFromRedTeam(this);
        Destroy(this.gameObject, 2f);
        this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        CombatStartObserver.instance.unitList.Remove(this);
        CombatManager.instance.redTeam.Remove(this);
    }
    public void NotifyStart()
    {
     //   ChangeState(searchingState);
    }

}
