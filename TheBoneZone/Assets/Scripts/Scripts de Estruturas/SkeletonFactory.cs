using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonFactory : MonoBehaviour
{
    [SerializeField]
    GameObject skeletonPrefab;
    [SerializeField]
    Transform spawnPoint;

    public GameObject skeletonList, skeletonListContainer;
    [SerializeField]
    GameObject skeletonOnListPrefab;


    public void EnqueueSkeleton()//adiciona um esqueleto na fila de criação
    {
        if (GameManager.instance.resourceManager.resourceFlyweight.calcium < 100) return;

        if (GameManager.instance.listManager.listaEsqueletos.Count + skeletonListContainer.transform.childCount
            < GameManager.instance.maxSkeletons)
        {
            GameManager.instance.UpdateCalcium(-100);
            Instantiate(skeletonOnListPrefab, skeletonListContainer.transform);
        }
        if (skeletonListContainer.transform.childCount == 1)
        {
            skeletonList.SetActive(true);
        }
    }

    public GameObject CreateSkeleton()
    {
        GameObject skeletonBeingSpawnedObj = Instantiate(skeletonPrefab, spawnPoint.position, Quaternion.Euler(0, 180, 0));

        //Skeleton skeletonClass = skeletonBeingSpawnedObj.GetComponent<Skeleton>();
        //skeletonClass.ChangeState(skeletonClass.myStats.spawningState);

        return skeletonBeingSpawnedObj;
    }

    public void ActivateSkeleton(GameObject skeletonToActivate, Skeleton skeletonClass)//ativa o obj do esqueleto
    {
        skeletonToActivate.GetComponent<NavMeshAgent>().enabled = true;
        skeletonToActivate.GetComponent<CapsuleCollider>().enabled = true;
        skeletonClass.spawned = true;
        //skeletonClass.ChangeState(skeletonClass.myStats.idleState);
        UnitSelection.Instance.unitList.Add(skeletonClass);
        Destroy(skeletonClass.spawningCircle);
        GameManager.instance.UpdateSkeletonCount();
    }
    public void ActivateSkeleton(Skeleton skeletonClass, GameObject skeletonObj, bool isAgentEnabled)
    {
        skeletonObj.GetComponent<NavMeshAgent>().enabled = isAgentEnabled;
        skeletonObj.GetComponent<CapsuleCollider>().enabled = true;
        UnitSelection.Instance.unitList.Add(skeletonClass);
        skeletonClass.ChangeAnimationState("Idle");
        Destroy(skeletonClass.spawningCircle);
        GameManager.instance.UpdateSkeletonCount();
    }

    public void CreateSkeleton(SkeletonData data)
    {
        GameObject skeleton = Instantiate(skeletonPrefab, data.position, Quaternion.Euler(data.rotation));
        Skeleton skeletonClass = skeleton.GetComponent<Skeleton>();
        skeletonClass.energy = data.energy;
        skeletonClass.tirednessCoefficient = data.tirednessCoefficient;
        skeletonClass.goldPocket = data.goldPocket;
        skeletonClass.efficiency = data.efficiency;
        skeletonClass.amountInBag = data.amountInBag;

        skeletonClass.isBuilding = data.isBuilding;
        skeletonClass.isGrinding = data.isGrinding;
        skeletonClass.isResting = data.isResting;
        skeletonClass.isFarming = data.isFarming;
        skeletonClass.isDelivering = data.isDelivering;
        skeletonClass.spawned = data.spawned;
        skeletonClass.reseted = data.reseted;



        ActivateSkeleton(skeletonClass, skeleton, data.isAgentEnabled);

        //skeletonClass.currentState = data.currentState;

    }

}
