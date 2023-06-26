using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class SkeletonData 
{
    public Vector3 position;
    public Vector3 rotation;

    public float energy;
    public float tirednessCoefficient;
    public float efficiency;
    public float goldPocket;
    public float amountInBag;
    public bool walking;
    public bool isAgentEnabled;
    public int farmingSpotID;
    public int pubID;
    public int grinderID;

    public bool spawned;

    public bool isFarming;
    public bool isDelivering;
    public bool isGrinding;
    public bool isBuilding;
    public bool isResting;

    public bool reseted;


}
[Serializable]
public class SkeletonAdapter : SkeletonData
{
    public SkeletonAdapter(Skeleton skeleton)
    {
        position = skeleton.transform.position;
        rotation = skeleton.transform.rotation.eulerAngles;
        energy = skeleton.energy;
        tirednessCoefficient= skeleton.tirednessCoefficient;
        efficiency = skeleton.efficiency;
        goldPocket= skeleton.goldPocket;
        amountInBag = skeleton.amountInBag;
        walking = skeleton.walking;
        isAgentEnabled = skeleton.agent.enabled;
        farmingSpotID= skeleton.farmingSpotID;
        pubID = skeleton.pubID;
        grinderID = skeleton.grinderID;

        isFarming = skeleton.isFarming;
        isDelivering = skeleton.isDelivering;
        isGrinding= skeleton.isGrinding;
        isBuilding= skeleton.isBuilding;
        isResting= skeleton.isResting;

        spawned= skeleton.spawned;
        reseted= skeleton.reseted;

    }
}
