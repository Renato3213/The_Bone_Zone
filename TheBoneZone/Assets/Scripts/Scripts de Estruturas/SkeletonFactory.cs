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
        if (GameManager.instance.Calcio < 100) return;

        if (GameManager.instance.ListManager.listaEsqueletos.Count + skeletonListContainer.transform.childCount
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

        Skeleton skeletonClass = skeletonBeingSpawnedObj.GetComponent<Skeleton>();
        skeletonClass.ChangeState(skeletonClass.myStats.spawningState);

        return skeletonBeingSpawnedObj;
    }

    public void ActivateSkeleton(GameObject skeletonToActivate, Skeleton skeletonClass)//ativa o obj do esqueleto
    {
        skeletonToActivate.GetComponent<NavMeshAgent>().enabled = true;
        skeletonToActivate.GetComponent<CapsuleCollider>().enabled = true;
        skeletonClass.ChangeState(skeletonClass.myStats.idleState);
        UnitSelection.Instance.unitList.Add(skeletonClass);
        Destroy(skeletonClass.spawningCircle);
        GameManager.instance.UpdateSkeletonCount();
    }

}
