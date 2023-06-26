using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class SceneData
{
    public ResourceData resourceData;

    public List<SkeletonData> skeletons;

    public List<HouseData> houses;
    public List<PubData> pubs;
    public List<GrinderData> grinders;
    public List<FarmingSpotData> farmingSpots;

    public List<LevelNodeData> levelNodes;

    public SceneData()
    {
        resourceData = null;
        skeletons = new List<SkeletonData>();
        skeletons.Clear();
        houses = new List<HouseData>();
        houses.Clear();
        pubs = new List<PubData>();
        pubs.Clear();
        grinders = new List<GrinderData>();
        grinders.Clear();
        farmingSpots = new List<FarmingSpotData>();
        farmingSpots.Clear();
        levelNodes = new List<LevelNodeData>();
        levelNodes.Clear();
    }

}