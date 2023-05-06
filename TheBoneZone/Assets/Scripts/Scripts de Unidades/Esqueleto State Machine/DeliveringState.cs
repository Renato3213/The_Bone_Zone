using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveringState : SkeletonState
{
    Vector3 closestGrinderPosition;
    Fazendas closestGrinder;
    FarmingSpot mySpot;
    public override void DoState(Skeleton skeleton)
    {
        //if (skeleton.walking == true && !initiated)
        //{
        //    initiated = false;
        //    return;
        //}

        if (!skeleton.stateInitialized)
        {
            skeleton.stateInitialized = true;
            FindClosestGrinder(skeleton);
        }
        GetTired(skeleton);

    }

    void GetTired(Skeleton skeleton)
    {
        skeleton.energy -= Time.deltaTime / skeleton.myStats.workTime < 0 ? 0 : Time.deltaTime / skeleton.myStats.workTime;

        if (skeleton.energy == 0) skeleton.tirednessCoefficient = 0.25f;
    }
    void FindClosestGrinder(Skeleton skeleton)
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
        skeleton.StartCoroutine(Deliver(skeleton, closestGrinder));
    }

    public IEnumerator Deliver(Skeleton skeleton, Fazendas grinder)
    {
        skeleton.MoveTo(closestGrinderPosition);
        while (Vector3.Distance(skeleton.transform.position, closestGrinderPosition) > 2.5f)
        {
            //if(Vector3.Distance(skeleton.transform.position, closestGrinderPosition) <= 1.5f)
            //{
            //    skeleton.agent.isStopped = true;
            //    skeleton.walking = false;
            //    break;
            //}
            yield return null;
        }
        skeleton.MoveTo(skeleton.transform.position);
        skeleton.agent.isStopped = true;
        skeleton.walking = false;
        while (grinder.bonesStored >= grinder.myStats.grinderStorageLimit)
        {
            yield return null;
        }

        skeleton.transform.LookAt(grinder.transform, Vector3.up);
        skeleton.ChangeAnimationState("Building");
        grinder.bonesStored += skeleton.amountInBag;

        skeleton.amountInBag = grinder.bonesStored - grinder.myStats.grinderStorageLimit < 0? 0 
                                : grinder.bonesStored - grinder.myStats.grinderStorageLimit;

        if (grinder.bonesStored > grinder.myStats.grinderStorageLimit)
        {
            grinder.bonesStored = grinder.myStats.grinderStorageLimit;
        }

        yield return new WaitForSeconds(1f);
        ReturnToFarming(skeleton);
        yield return null;
    }

    public void ReturnToFarming(Skeleton skeleton)
    {
        skeleton.ChangeAnimationState("Walk");
        skeleton.agent.isStopped = false;
        skeleton.MoveTo(skeleton.farmingSpot.transform.position);
        skeleton.stateInitialized = false;
        skeleton.ChangeState(skeleton.myStats.farmingState);

    }

}
