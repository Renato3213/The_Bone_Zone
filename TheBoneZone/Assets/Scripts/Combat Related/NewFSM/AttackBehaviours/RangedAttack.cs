using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackPattern", menuName = "AttackBehaviours/RangedAttack", order = 1)]
public class RangedAttack : AttackBehaviours
{
    public override void Attack(CombatUnit attacker, CombatUnit target)
    {
        target.TakeDamage(attacker.attackPower);
    }
}
