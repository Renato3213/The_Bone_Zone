using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningState : SkeletonState
{
    
    public override void DoState(Skeleton skeleton)
    {

        if (!skeleton.stateInitialized)
        {
            skeleton.stateInitialized = true;
            ChooseRandomAnimation(skeleton);
        }
    }

    void ChooseRandomAnimation(Skeleton skeleton)
    {
        int i = Random.Range(0, 3);
        skeleton.ChangeAnimationState(skeleton.myStats.spawnAnimations[i].name);
    }
}
