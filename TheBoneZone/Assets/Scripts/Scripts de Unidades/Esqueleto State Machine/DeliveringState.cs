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
        //if (skeleton.walking == true && !initiated)
        //{
        //    initiated = false;
        //    return;
        //}

        if (!initiated)
        {
            initiated = true;
            FindClosestGrinder(skeleton);
            Debug.Log("inicia");
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
        Debug.Log("found");
    }

    public IEnumerator Deliver(Skeleton skeleton, Fazendas grinder)
    {
        Debug.Log("vai la porras");
        skeleton.MoveTo(closestGrinderPosition);
        while (Vector3.Distance(skeleton.transform.position, closestGrinderPosition) > 2.5f)
        {
                Debug.Log("chego n");
            //if(Vector3.Distance(skeleton.transform.position, closestGrinderPosition) <= 1.5f)
            //{
            //    skeleton.agent.isStopped = true;
            //    skeleton.walking = false;
            //    break;
            //}
            yield return null;
        }
        Debug.Log("chego");
        skeleton.MoveTo(skeleton.transform.position);
        skeleton.agent.isStopped = true;
        skeleton.walking = false;
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
        Debug.Log("!");
        ReturnToFarming(skeleton);
        yield return null;
    }

    public void ReturnToFarming(Skeleton skeleton)
    {
        skeleton.ChangeAnimationState("Walk");
        skeleton.agent.isStopped = false;
        skeleton.MoveTo(skeleton.farmingSpot.transform.position);
        initiated = false;
        skeleton.currentState = skeleton.farmingState;

    }

}
