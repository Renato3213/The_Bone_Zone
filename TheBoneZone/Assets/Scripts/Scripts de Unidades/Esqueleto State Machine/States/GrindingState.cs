using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrindingState : ISkeletonState
{
    Skeleton skeleton;
    Fazendas grinder;


    Vector3 closestGrinderPosition;
    Fazendas closestGrinder;
    public void OnEnter(Skeleton skeleton)
    {
        this.skeleton = skeleton;
        ControlaListas.instance.skeletonsGrinding.Add(skeleton);
        skeleton.transform.position = GameManager.instance.deposit.transform.position;
        skeleton.agent.enabled = false;

        if(skeleton.grinderID == -1)
        {
            if(skeleton.grinderTarget!= null)
            {
                grinder = skeleton.grinderTarget;
                skeleton.grinderID = grinder.myId;
                grinder.trabalhandoAqui.Add(skeleton);
                grinder.myInterface.Atualiza();
            }
        }

        else
        {
            grinder = ControlaListas.instance.grindersList.Find((grinder) => grinder.myId == skeleton.grinderID);
            grinder.trabalhandoAqui.Add(skeleton);
        }
        

        //if(grinder != null )
        //    grinder.workingHere++;
    }

    public void OnExit()
    {
        ControlaListas.instance.skeletonsGrinding.Remove(skeleton);
        grinder.workingHere--;
    }

    Fazendas FindClosestGrinder(Skeleton skeleton)
    {

        closestGrinderPosition = Vector3.positiveInfinity;
        Vector3 grinderPosition;
        foreach (Fazendas grinder in ControlaListas.instance.grindersList)
        {
            grinderPosition = grinder.transform.position;
            if (Vector3.Distance(skeleton.transform.position, grinderPosition) < Vector3.Distance(skeleton.transform.position, closestGrinderPosition))
            {
                closestGrinder = grinder;
                closestGrinderPosition = grinderPosition;
            }
        }

        return closestGrinder;
    }


    public void OnUpdate()
    {
        Grind(skeleton);
        skeleton.GetTired();
    }
    //{
    //    if (skeleton.walking == true &&
    //        Vector3.Distance(skeleton.transform.position, skeleton.grinderTarget.transform.position) >= 2.5f)
    //    {
    //        skeleton.stateInitialized = false;

    //        return;
    //    }


    //    if (!skeleton.stateInitialized)
    //    {
    //        skeleton.stateInitialized = true;
    //        skeleton.walking = false;
    //        skeleton.doingTask = true;
    //        grinder = skeleton.grinderTarget;

    //        skeleton.agent.isStopped = true;
    //        skeleton.agent.enabled = false;
    //        skeleton.transform.position = GameManager.instance.deposit.transform.position;
    //        grinder.myInterface.Atualiza();
    //    }
    //    Grind(skeleton);
    //    GetTired(skeleton);

    //}

    //void GetTired(Skeleton skeleton)
    //{
    //    skeleton.energy -= Time.deltaTime / skeleton.myStats.workTime < 0 ? 0 : Time.deltaTime / skeleton.myStats.workTime;

    //    if (skeleton.energy == 0) skeleton.tirednessCoefficient = 0.25f;
    //}

    public void Grind(Skeleton skeleton)
    {
        if (grinder.bonesStored > 0)
        {
            GameManager.instance.UpdateCalcium(Time.deltaTime * skeleton.myStats.grindingSpeed);
            grinder.bonesStored = grinder.bonesStored - (Time.deltaTime * skeleton.myStats.grindingSpeed) < 0 ? 0 : grinder.bonesStored - (Time.deltaTime * skeleton.myStats.grindingSpeed);
        }
    }


}
