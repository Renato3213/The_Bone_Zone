using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingState : ISkeletonState
{

    Skeleton skeleton;
    FarmingSpot myFarmingSpot;
    public void OnEnter(Skeleton skeleton)
    {
        this.skeleton = skeleton;
        skeleton.walking = false;

        if (skeleton.farmingSpot != null)
        {
            myFarmingSpot = skeleton.farmingSpot;   
            skeleton.farmingSpotID = myFarmingSpot.myId;
        }
        else if(skeleton.farmingSpotID != -1)
        {
            myFarmingSpot = ControlaListas.instance.farmingSpotList.Find((fs) => fs.myId == skeleton.farmingSpotID);
        }

        skeleton.agent.isStopped = true;
        skeleton.ChangeAnimationState("Building");
    }

    public void OnUpdate()
    {
        skeleton.GetTired();

        if (skeleton.amountInBag < skeleton.myStats.maxBagCapacity)
        {
            skeleton.amountInBag += Time.deltaTime * skeleton.myStats.farmingSpeed;
            return;
        }
        else if (skeleton.amountInBag > skeleton.myStats.maxBagCapacity)
        {
            skeleton.amountInBag = skeleton.myStats.maxBagCapacity;
        }
        //the bag is now full
        Deliver(skeleton);
    }
    void Deliver(Skeleton skeleton)
    {
        skeleton.agent.isStopped = false;
        
    }

    public void OnExit()
    {
        
    }


}
