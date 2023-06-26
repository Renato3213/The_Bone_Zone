using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveringState : ISkeletonState
{
    Skeleton skeleton;
    Vector3 closestGrinderPosition;
    Fazendas closestGrinder;
    FarmingSpot mySpot;
    float animationTime;
    public void OnEnter(Skeleton skeleton)
    {
        
        animationTime = 1f;
        this.skeleton = skeleton;
        skeleton.isDelivering = true;
        FindClosestGrinder(skeleton);
        skeleton.agent.isStopped = false;
        skeleton.ChangeAnimationState("Walk");
        skeleton.MoveTo(closestGrinderPosition);

        if(skeleton.farmingSpot!=null)
        {
            mySpot = skeleton.farmingSpot;
        }
        else
        {
            mySpot = ControlaListas.instance.farmingSpotList.Find((fs) => fs.myId == skeleton.farmingSpotID);
        }
    }
    public void OnUpdate()
    {
        skeleton.GetTired();

        if (Vector3.Distance(skeleton.transform.position, closestGrinderPosition) <= 2.5f)
        {
            skeleton.agent.isStopped = true;

            if (closestGrinder.bonesStored >= closestGrinder.myStats.grinderStorageLimit)
            {
                skeleton.ChangeAnimationState("Idle");
                return;
            }
            skeleton.transform.LookAt(closestGrinder.transform, Vector3.up);
            skeleton.ChangeAnimationState("Building");
            closestGrinder.bonesStored += skeleton.amountInBag;

            skeleton.amountInBag = closestGrinder.bonesStored - closestGrinder.myStats.grinderStorageLimit < 0 ? 0
                                : closestGrinder.bonesStored - closestGrinder.myStats.grinderStorageLimit;

            if (closestGrinder.bonesStored > closestGrinder.myStats.grinderStorageLimit)
            {   
                closestGrinder.bonesStored = closestGrinder.myStats.grinderStorageLimit;
            }

            skeleton.ChangeAnimationState("Building");//placeholder

            if(animationTime > 0)
            {
                animationTime -= Time.deltaTime;
                return;
            }

            ReturnToFarming(skeleton);

        }
    }

    public void OnExit()
    {

    }

    //public override void DoState(Skeleton skeleton)
    //{
    //    //if (skeleton.walking == true && !initiated)
    //    //{
    //    //    initiated = false;
    //    //    return;
    //    //}

    //    if (!skeleton.stateInitialized)
    //    {
    //        skeleton.stateInitialized = true;
    //        FindClosestGrinder(skeleton);
    //    }
    //    GetTired(skeleton);

    //}


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
        //skeleton.StartCoroutine(Deliver(skeleton, closestGrinder));
    }

    //public IEnumerator Deliver(Skeleton skeleton, Fazendas grinder)
    //{
    //    skeleton.MoveTo(closestGrinderPosition);
    //    while (Vector3.Distance(skeleton.transform.position, closestGrinderPosition) > 1.5f)
    //    {
    //        //if(Vector3.Distance(skeleton.transform.position, closestGrinderPosition) <= 1.5f)
    //        //{
    //        //    skeleton.agent.isStopped = true;
    //        //    skeleton.walking = false;
    //        //    break;
    //        //}
    //        yield return null;
    //    }
    //    skeleton.MoveTo(skeleton.transform.position);
    //    skeleton.agent.isStopped = true;
    //    skeleton.walking = false;
    //    while (grinder.bonesStored >= grinder.myStats.grinderStorageLimit)
    //    {
    //        yield return null;
    //    }

    //    skeleton.transform.LookAt(grinder.transform, Vector3.up);
    //    skeleton.ChangeAnimationState("Building");
    //    grinder.bonesStored += skeleton.amountInBag;

    //    skeleton.amountInBag = grinder.bonesStored - grinder.myStats.grinderStorageLimit < 0 ? 0
    //                            : grinder.bonesStored - grinder.myStats.grinderStorageLimit;

    //    if (grinder.bonesStored > grinder.myStats.grinderStorageLimit)
    //    {
    //        grinder.bonesStored = grinder.myStats.grinderStorageLimit;
    //    }

    //    yield return new WaitForSeconds(1f);
    //    ReturnToFarming(skeleton);
    //    yield return null;
    //}

    public void ReturnToFarming(Skeleton skeleton)
    {
        skeleton.agent.isStopped = false;
        skeleton.isFarming = true;
        skeleton.isDelivering = false;
        skeleton.MoveTo(mySpot.transform.position);
        //skeleton.stateInitialized = false;
        //skeleton.ChangeState(skeleton.myStats.farmingState);

    }


}
