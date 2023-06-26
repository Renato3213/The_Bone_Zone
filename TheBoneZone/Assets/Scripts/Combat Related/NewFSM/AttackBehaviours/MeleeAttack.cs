using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackPattern", menuName = "AttackBehaviours/MeleeAttack", order = 1)]
public class MeleeAttack : AttackBehaviours
{
    public override void Attack(CombatUnit attacker, CombatUnit target)
    {
        target?.TakeDamage(attacker.attackPower);
        if(attacker.animator != null)
        {
            attacker.animator.Play("Attack");

        }
    }



}
