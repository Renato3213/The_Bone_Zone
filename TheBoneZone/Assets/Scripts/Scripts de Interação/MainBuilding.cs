using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : Interaction
{
    public static MainBuilding instance;
    public GameObject _interface;
    public GameObject missionInterface;

    public SkeletonFactory skeletonFactory;

    private void Awake()
    {
        instance = this;
        skeletonFactory = transform.GetComponent<SkeletonFactory>();
        GameManager.instance.maxSkeletons += 10;
        GameManager.instance.UpdateSkeletonCount();
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

}
