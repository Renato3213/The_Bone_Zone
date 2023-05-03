using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveringState : SkeletonState
{
    bool initiated = false;
    Vector3 closestGrinderPosition;
    Fazendas closestGrinder;
    FarmingSpot mySpot;
    public override void DoState(Skeleton skeleton)
    {
        if (!initiated)
        {
            initiated = true;
            FindClosestGrinder(skeleton);
        }
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
        while (skeleton.walking)
        {
            if(Vector3.Distance(skeleton.transform.position, grinder.transform.position) <= 1.5f)
            {
                skeleton.agent.isStopped = true;
                break;
            }
            yield return null;
        }

        while (grinder.bonesStored >= grinder.storageLimit)
        {
            yield return null;
        }

        skeleton.transform.LookAt(grinder.transform, Vector3.up);
        skeleton.ChangeAnimationState("Building");
        grinder.bonesStored += skeleton.amountInBag;

        skeleton.amountInBag = grinder.bonesStored - grinder.storageLimit < 0? 0 
                                : grinder.bonesStored - grinder.storageLimit;

        if (grinder.bonesStored > grinder.storageLimit)
        {
            grinder.bonesStored = grinder.storageLimit;
        }

        yield return new WaitForSeconds(1f);
        ReturnToFarming(skeleton);
        yield return null;
    }

    public void ReturnToFarming(Skeleton skeleton)
    {
        skeleton.MoveTo(skeleton.farmingSpot.transform.position);
        skeleton.currentState = skeleton.farmingState;

    }

}
