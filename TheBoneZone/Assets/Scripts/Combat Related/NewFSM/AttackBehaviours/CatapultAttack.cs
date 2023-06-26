using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "AttackPattern", menuName = "AttackBehaviours/CatapultAttack" )]
public class CatapultAttack : AttackBehaviours
{

    public override void Attack(CombatUnit attacker, CombatUnit target)
    {
        SetParticlePosition( attacker, target );

        attacker.StartCoroutine(AttackRoutine(attacker));

        Debug.Log("atacou");
    }

    IEnumerator AttackRoutine(CombatUnit attacker)
    {
        attacker.animator.Play("Attack");
        yield return new WaitForSeconds(0.15f);
        attacker.attackEffect.Play();

        while(attacker.attackEffect.particleCount > 0)
        {
            yield return null;
        }

        DamageInRadius(attacker);
    
    }

    void DamageInRadius(CombatUnit attacker)
    {
        Collider[] hitColliders = Physics.OverlapSphere(attacker.attackEffect.transform.position, 1.5f);

        List<CombatUnit> unitsInRadius = new List<CombatUnit>();


        foreach (Collider col in hitColliders)
        {
            CombatUnit unitToAdd;
            if (col.gameObject.TryGetComponent<CombatUnit>(out unitToAdd))
            {
                unitsInRadius.Add(unitToAdd);
            }
        }

        foreach (CombatUnit unit in unitsInRadius)
        {
            if (attacker.OpositeTeam.Contains(unit))
            {
                unit.TakeDamage(attacker.attackPower);
            }
        }

    }


    void SetParticlePosition(CombatUnit attacker, CombatUnit target)
    {
        attacker.attackEffect.transform.position = target.transform.position;
        attacker.attackEffect.transform.LookAt(attacker.transform.position);

        ParticleSystem.ShapeModule shape = attacker.attackEffect.shape;

        float distance = Vector3.Distance(target.transform.position, attacker.transform.position);
        shape.position = new Vector3(0, 5, distance - 1);
    }
}
