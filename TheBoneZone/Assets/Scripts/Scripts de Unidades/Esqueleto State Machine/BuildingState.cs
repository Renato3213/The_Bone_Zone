using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : SkeletonState
{
    UnderConstruction buildingTarget;
    float timeInterval = 1.5f;
    public override void DoState(Skeleton skeleton)
    {

        if (skeleton.walking == true)
        {
            skeleton.stateInitialized = false;
            return;
        }

        if (!skeleton.stateInitialized)
        {
            skeleton.stateInitialized = true;
            skeleton.walking = false;
            buildingTarget = skeleton.buildingTarget;
            skeleton.StartCoroutine(Build(skeleton, buildingTarget));
        }
        GetTired(skeleton);

    }

    void GetTired(Skeleton skeleton)
    {
        skeleton.energy -= Time.deltaTime / skeleton.myStats.workTime < 0? 0 : Time.deltaTime / skeleton.myStats.workTime;

        if (skeleton.energy == 0) skeleton.tirednessCoefficient = 0.25f;
    }

    IEnumerator Build(Skeleton skeleton, UnderConstruction building)
    {
        float interval = timeInterval;

        while (!IsBuildingDone(building))
        {
            skeleton.transform.LookAt(building.transform, Vector3.up);
            skeleton.ChangeAnimationState("Building");
            skeleton.agent.isStopped = true;
            if (interval <= 0)
            {
                skeleton.transform.position = building.RandomPointAroundBuilding();
                interval = timeInterval;
            }
            building.Build(Time.deltaTime / skeleton.myStats.buildingSpeed);
            interval -= Time.deltaTime;
            yield return null;
        }

        ReturnToIdle(skeleton);

        yield return null;
    }

    void ReturnToIdle(Skeleton skeleton)
    {
        skeleton.agent.isStopped = false;
        skeleton.walking = false;

        if (ControlaListas.instance.beingConstructedList.Count > 0)
        {
            skeleton.StopAllCoroutines();
            skeleton.stateInitialized = false;
            skeleton.buildingTarget = ControlaListas.instance.beingConstructedList[0];
            skeleton.MoveTo(skeleton.buildingTarget.RandomPointAroundBuilding());
            skeleton.ChangeState(skeleton.myStats.buildingState);
        }
        else
        {
            skeleton.doingTask = false;
            skeleton.ChangeState(skeleton.myStats.idleState);
            skeleton.ChangeAnimationState("Idle");
            skeleton.MoveTo(skeleton.transform.position);
        }
    }

    bool IsBuildingDone(UnderConstruction building)
    {
        if (building.progress >= 1 || building == null) return true;
        else return false;
    }

}
