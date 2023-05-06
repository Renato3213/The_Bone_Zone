using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingState : SkeletonState
{

    FarmingSpot myFarmingSpot;
    
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
            myFarmingSpot = skeleton.farmingSpot;
            skeleton.StartCoroutine(Farm(skeleton, myFarmingSpot));
        }
        GetTired(skeleton);

    }

    void GetTired(Skeleton skeleton)
    {
        skeleton.energy -= Time.deltaTime / skeleton.myStats.workTime < 0 ? 0 : Time.deltaTime / skeleton.myStats.workTime;

        if (skeleton.energy == 0) skeleton.tirednessCoefficient = 0.25f;
    }
    IEnumerator Farm(Skeleton skeleton, FarmingSpot farmingSpot)
    {
        skeleton.ChangeAnimationState("Building");
        while (skeleton.amountInBag < skeleton.myStats.maxBagCapacity)
        {
            skeleton.agent.isStopped = true;
            skeleton.amountInBag += Time.deltaTime * skeleton.myStats.farmingSpeed ;
            yield return null;
        }
        if(skeleton.amountInBag > skeleton.myStats.maxBagCapacity)
        {
            skeleton.amountInBag = skeleton.myStats.maxBagCapacity;
        }
        //the bag is now full
        Deliver(skeleton);

        yield return null;
    }

    void Deliver(Skeleton skeleton)
    {
        skeleton.doingTask= false;
        skeleton.agent.isStopped = false;
        skeleton.ChangeAnimationState("Idle");
        skeleton.MoveTo(skeleton.transform.position);
        skeleton.doingTask = true;
        skeleton.ChangeState(skeleton.myStats.deliveringState);
    }

}
