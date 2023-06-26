using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackPattern", menuName = "AttackBehaviours/RangedAttack", order = 1)]
public class RangedAttack : AttackBehaviours
{
    public override void Attack(CombatUnit attacker, CombatUnit target)
    {
        SetParticlePosition(attacker, target);

        attacker.attackEffect.Play();
        attacker.StartCoroutine(AttackRoutine(attacker, target));

        Debug.Log("atacou");
    }

    IEnumerator AttackRoutine(CombatUnit attacker, CombatUnit target)
    {
        //attacker.animator.Play("Attack");
        attacker.attackEffect.Play();
        yield return new WaitForSeconds(0.15f);

        target.TakeDamage(attacker.attackPower);
    }

    void SetParticlePosition(CombatUnit attacker, CombatUnit target)
    {
        Vector3 particlePosition = new Vector3(target.transform.position.x, target.transform.position.y + 1, target.transform.position.z);
        attacker.attackEffect.transform.position = particlePosition;
        attacker.attackEffect.transform.LookAt(attacker.transform.position);

        ParticleSystem.ShapeModule shape = attacker.attackEffect.shape;

        float distance = Vector3.Distance(target.transform.position, attacker.transform.position);
        shape.position = new Vector3(0, 0, distance - 1);

        ParticleSystem.CollisionModule collisions = attacker.attackEffect.collision;

        collisions.AddPlane(target.transform);
    }

}
