using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkeletonStats", menuName = "ScriptableObjects/Create Skeleton Stats")]
public class SkeletonFlyweight : ScriptableObject
{
    //public SkeletonState idleState = new IdleState();
    //public SkeletonState farmingState = new FarmingState();
    //public SkeletonState buildingState = new BuildingState();
    //public SkeletonState walkingState = new WalkingState();
    //public SkeletonState deliveringState = new DeliveringState();
    //public SkeletonState grindingState = new GrindingState();
    //public SkeletonState restingState = new RestingState();

    //public SkeletonState spawningState = new SpawningState();

    public AnimationClip[] spawnAnimations;
    public float buildingSpeed;
    public float maxBagCapacity;
    public float farmingSpeed;
    public float grindingSpeed;
    public float minimumWage;
    public float maxMovespeed;
    public float workTime;

    public float happinessCoefficient = 0.5f;

}
