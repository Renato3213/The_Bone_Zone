using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFactory : MonoBehaviour
{
    [SerializeField]
    GameObject skeletonPrefab;
    [SerializeField]
    Transform spawnPoint;

    public GameObject skeletonList, skeletonListContainer;
    [SerializeField] 
    GameObject skeletonOnListPrefab;

    public void InstantiateSkeleton()//instancia o obj do esqueleto
    {
        Instantiate(skeletonPrefab, spawnPoint.position, Quaternion.identity);
        GameManager.instance.UpdateSkeletonCount();
    }

    public void CreateSkeleton()//adiciona um esqueleto na fila de criação
    {
        if (GameManager.instance.Calcio < 100) return;
        else if (GameManager.instance.listas.listaEsqueletos.Count + skeletonListContainer.transform.childCount
            < GameManager.instance.maxSkeletons)
        {
            GameManager.instance.AtualizaCalcio(-100);
            Instantiate(skeletonOnListPrefab, skeletonListContainer.transform);

            if (skeletonListContainer.transform.childCount == 1)
            {
                skeletonList.SetActive(true);
            }
        }
    }
}
