using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrindingState : SkeletonState
{
    Fazendas grinder;
    public override void DoState(Skeleton skeleton)
    {
        if (skeleton.walking == true &&
            Vector3.Distance(skeleton.transform.position, skeleton.grinderTarget.transform.position) >= 2.5f)
        {
            skeleton.stateInitialized = false;

            return;
        }


        if (!skeleton.stateInitialized)
        {
            skeleton.stateInitialized = true;
            skeleton.walking = false;
            skeleton.doingTask = true;
            grinder = skeleton.grinderTarget;

            skeleton.agent.isStopped = true;
            skeleton.agent.enabled = false;
            skeleton.transform.position = GameManager.instance.deposit.transform.position;
            grinder.myInterface.Atualiza();
        }
        Grind(skeleton);
        GetTired(skeleton);

    }

    void GetTired(Skeleton skeleton)
    {
        skeleton.energy -= Time.deltaTime / skeleton.myStats.workTime < 0 ? 0 : Time.deltaTime / skeleton.myStats.workTime;

        if (skeleton.energy == 0) skeleton.tirednessCoefficient = 0.25f;
    }

    public void Grind(Skeleton skeleton)
    {
        if (grinder.bonesStored > 0)
        {
            GameManager.instance.UpdateCalcium(Time.deltaTime *skeleton.myStats.grindingSpeed);
            grinder.bonesStored = grinder.bonesStored - (Time.deltaTime * skeleton.myStats.grindingSpeed ) < 0? 0 : grinder.bonesStored - (Time.deltaTime * skeleton.myStats.grindingSpeed);
        }
    }

}
