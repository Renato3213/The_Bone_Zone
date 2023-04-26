using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningState : SkeletonState
{
    bool initialized = false;
    public override void DoState(Skeleton skeleton)
    {
        if (!initialized)
        {
            initialized = true;
            ChooseRandomAnimation(skeleton);
        }
    }

    void ChooseRandomAnimation(Skeleton skeleton)
    {
        int i = Random.Range(0, 3);
        skeleton.ChangeAnimationState(skeleton.spawnAnimations[i].name);
    }
}
