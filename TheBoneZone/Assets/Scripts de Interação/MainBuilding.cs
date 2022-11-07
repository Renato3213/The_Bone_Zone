using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : Interaction
{
    public static MainBuilding instance;
    public GameObject _interface;
    public GameObject missionInterface;
    public GameObject skeletonPrefab;
    public Transform spawnPoint;

    public GameObject skeletonList, skeletonListContainer;
    public GameObject skeletonOnListPrefab;

    private void Awake()
    {
        instance = this;
        GameManager.instance.maxSkeletons += 10;
        GameManager.instance.UpdateSkeletonCount();
        GameManager.instance.AtualizaCalcio(2000);
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Interact();
        }
    }

    public override void Interact()
    {
        GameManager.instance.UpdateActiveInterface(_interface);
    }

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
