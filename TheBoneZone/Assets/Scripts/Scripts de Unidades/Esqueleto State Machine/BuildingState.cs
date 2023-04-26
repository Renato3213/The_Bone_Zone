using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : SkeletonState
{
    bool initiated;
    UnderConstruction buildingTarget;
    float timeInterval = 1.5f;
    public override void DoState(Skeleton skeleton)
    {
        Debug.Log("building");
        if(skeleton.walking == true)
        {
            Debug.Log("ainda não chegou");
            initiated = false;
            return;
        }

        if (!initiated)
        {
            initiated = true;
            skeleton.walking = false;
            buildingTarget = skeleton.buildingTarget;
            skeleton.StartCoroutine(Build(skeleton, buildingTarget));
            Debug.Log("chegou");
        }
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
            building.Build(Time.deltaTime / skeleton.buildingSpeed);
            interval -= Time.deltaTime;
            yield return null;
        }

        ReturnToIdle(skeleton);

        yield return null;
    }

    void ReturnToIdle(Skeleton skeleton)
    {
        skeleton.doingTask = false;
        skeleton.agent.isStopped = false;
        skeleton.walking = false;
        skeleton.currentState = skeleton.idleState;
        skeleton.ChangeAnimationState("Idle");
        skeleton.MoveTo(skeleton.transform.position);
    }

    bool IsBuildingDone(UnderConstruction building)
    {
        if (building.progress >= 1 || building == null) return true;
        else return false;
    }
}
