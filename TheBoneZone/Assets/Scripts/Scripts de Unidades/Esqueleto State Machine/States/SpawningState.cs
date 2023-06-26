using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningState : ISkeletonState
{

    //public override void DoState(Skeleton skeleton)
    //{
    //if (!skeleton.stateInitialized)
    //{
    //    skeleton.stateInitialized = true;
    //    ChooseRandomAnimation(skeleton);
    //}

    //}

    Skeleton mySkeleton;
    public void OnEnter(Skeleton skeleton)
    {
        mySkeleton= skeleton;
        ChooseRandomAnimation(skeleton);
        
    }
    void ChooseRandomAnimation(Skeleton skeleton)
    {
        int i = Random.Range(0, 3);
        skeleton.ChangeAnimationState(skeleton.myStats.spawnAnimations[i].name);
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        
    }
}
