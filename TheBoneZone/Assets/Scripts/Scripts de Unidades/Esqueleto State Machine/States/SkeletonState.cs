using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class SkeletonState
{
    public virtual void DoState(Skeleton skeleton) { }
    
    
}
