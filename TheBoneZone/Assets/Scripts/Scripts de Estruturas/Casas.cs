using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Casas : MonoBehaviour
{

    public StructureFlyweight myStats;
    void Awake()
    {
        GameManager.instance.maxSkeletons += myStats.houseAditionalSlots;
        GameManager.instance.UpdateSkeletonCount();
    }

}
