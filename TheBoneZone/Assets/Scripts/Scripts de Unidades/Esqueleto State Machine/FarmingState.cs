using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingState : SkeletonState
{
    bool initiated;
    FarmingSpot myFarmingSpot;
    
    public override void DoState(Skeleton skeleton)
    {
        if (skeleton.walking == true)
        {
            initiated = false;
            return;
        }

        if (!initiated)
        {
            initiated = true;
            skeleton.walking = false;
            myFarmingSpot = skeleton.farmingSpot;
            skeleton.StartCoroutine(Farm(skeleton, myFarmingSpot));
        }
        Debug.Log("farming");
    }

    IEnumerator Farm(Skeleton skeleton, FarmingSpot farmingSpot)
    {
        Debug.Log("uepa");
        skeleton.ChangeAnimationState("Building");
        while (skeleton.amountInBag < skeleton.maxBagCapacity)
        {
            skeleton.agent.isStopped = true;
            skeleton.amountInBag = skeleton.amountInBag + (skeleton.farmingSpeed / Time.deltaTime) > skeleton.maxBagCapacity ? skeleton.maxBagCapacity : skeleton.amountInBag + (skeleton.farmingSpeed / Time.deltaTime);
            yield return null;
        }
        //the bag is now full
        Deliver(skeleton);

        yield return null;
    }

    void Deliver(Skeleton skeleton)
    {
        Debug.Log("entrega la");
        skeleton.doingTask= false;
        skeleton.agent.isStopped = false;
        skeleton.walking = false;
        skeleton.ChangeAnimationState("Idle");
        skeleton.MoveTo(skeleton.transform.position);
        skeleton.doingTask = true;
        skeleton.currentState = skeleton.deliveringState;
    }

}
