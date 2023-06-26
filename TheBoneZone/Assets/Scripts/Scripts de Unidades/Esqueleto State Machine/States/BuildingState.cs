using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : ISkeletonState
{
    UnderConstruction buildingTarget;
    float timeInterval = 1.5f;
    float interval;
    Skeleton skeleton;
    //public override void DoState(Skeleton skeleton)
    //{

    //    if (skeleton.walking == true)
    //    {
    //        skeleton.stateInitialized = false;
    //        return;
    //    }

    //    if (!skeleton.stateInitialized)
    //    {
    //        skeleton.stateInitialized = true;
    //        skeleton.walking = false;
    //        buildingTarget = skeleton.buildingTarget;
    //        skeleton.StartCoroutine(Build(skeleton, buildingTarget));
    //    }
    //    GetTired(skeleton);

    //}


    public void OnEnter(Skeleton skeleton)
    {
        this.skeleton = skeleton;
        skeleton.walking = false;
        skeleton.agent.isStopped = true;
        buildingTarget = skeleton.buildingTarget;
        interval = timeInterval;
        skeleton.buildingParticle.SetActive(true);
    }

    public void OnUpdate()
    {
        skeleton.GetTired();

        if (!IsBuildingDone(buildingTarget))
        {
            skeleton.buildingParticle.transform.position = buildingTarget.transform.position;
            skeleton.buildingPSystem.Play();
            skeleton.transform.LookAt(buildingTarget.transform, Vector3.up);
            skeleton.ChangeAnimationState("Building");
            skeleton.agent.isStopped = true;
            if (interval <= 0)
            {
                skeleton.buildingPSystem.Stop();
                skeleton.transform.position = buildingTarget.RandomPointAroundBuilding();
                interval = timeInterval;
            }
            buildingTarget.Build(Time.deltaTime / skeleton.myStats.buildingSpeed);
            interval -= Time.deltaTime;
            return;
        }
        SearchMoreToBuild(skeleton);
    }


    void SearchMoreToBuild(Skeleton skeleton)
    {
        

        if (ControlaListas.instance.beingConstructedList.Count > 0)
        {
            //skeleton.StopAllCoroutines();
            //skeleton.stateInitialized = false;
            skeleton.agent.isStopped = false;
            skeleton.buildingTarget = ControlaListas.instance.beingConstructedList[0];
            skeleton.MoveTo(skeleton.buildingTarget.RandomPointAroundBuilding());
            //skeleton.ChangeState(skeleton.myStats.buildingState);
        }
        else
        {
            //skeleton.doingTask = false;
            //skeleton.ChangeState(skeleton.myStats.idleState);
            //skeleton.ChangeAnimationState("Idle");
            //skeleton.MoveTo(skeleton.transform.position);
            skeleton.buildingTarget = null;
            skeleton.isBuilding = false;
        }
    }

    bool IsBuildingDone(UnderConstruction building)
    {
        if (building.progress >= 1 || building == null) return true;
        else return false;
    }

    public void OnExit()
    {
        skeleton.buildingParticle.SetActive(false);
    }


}
