using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StructureStats", menuName = "ScriptableObjects/Create Structure Stats")]
public class StructureFlyweight : ScriptableObject
{
    [Header("House")]
    public int houseAditionalSlots = 5;

    [Header("Grinder")]
    public int grinderSkeletonLimit = 4;
    public float grinderStorageLimit = 200f;

    //[Header("Pub")]

}
