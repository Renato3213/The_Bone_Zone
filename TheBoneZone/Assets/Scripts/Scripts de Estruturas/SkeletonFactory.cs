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


    GameObject skeletonBeingSpawnedObj;
    Skeleton skeletonBeingSpawnedClass;

    public void ActivateSkeleton()//ativa o obj do esqueleto
    {
        skeletonBeingSpawnedObj.GetComponent<UnitMovement>().enabled = true;
        skeletonBeingSpawnedObj.GetComponent<NavMeshAgent>().enabled = true;
        skeletonBeingSpawnedObj.GetComponent<CapsuleCollider>().enabled = true;
        skeletonBeingSpawnedClass.currentState = skeletonBeingSpawnedClass.idleState;
        Destroy(skeletonBeingSpawnedClass.spawningCircle);
        GameManager.instance.UpdateSkeletonCount();
    }

    public void CreateSkeleton()//adiciona um esqueleto na fila de criação
    {
        if (GameManager.instance.Calcio < 100) return;
        else if (GameManager.instance.listas.listaEsqueletos.Count + skeletonListContainer.transform.childCount
            < GameManager.instance.maxSkeletons)
        {
            skeletonBeingSpawnedObj = Instantiate(skeletonPrefab, spawnPoint.position, Quaternion.Euler(0,180,0));

            skeletonBeingSpawnedClass = skeletonBeingSpawnedObj.GetComponent<Skeleton>();
            skeletonBeingSpawnedClass.currentState = skeletonBeingSpawnedClass.spawningState;

            DeactivateSkeleton(skeletonBeingSpawnedObj);
            GameManager.instance.AtualizaCalcio(-100);
            Instantiate(skeletonOnListPrefab, skeletonListContainer.transform);

            if (skeletonListContainer.transform.childCount == 1)
            {
                skeletonList.SetActive(true);
            }
        }
    }

    public void CancelSpawn()
    {
        Destroy(skeletonBeingSpawnedObj);
        skeletonBeingSpawnedObj = null;
    }

    void DeactivateSkeleton(GameObject skeleton)
    {
        skeleton.GetComponent<UnitMovement>().enabled = false;
        skeleton.GetComponent<NavMeshAgent>().enabled = false;
        skeleton.GetComponent<CapsuleCollider>().enabled = false;
    }
}
