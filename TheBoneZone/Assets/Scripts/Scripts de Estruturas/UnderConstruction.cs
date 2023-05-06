using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderConstruction : MonoBehaviour
{
    public GameObject phantom, finishedObj;

    public float progress;

    public float radius;
    public LayerMask buildingLayer;

    private void Awake()
    {
        ControlaListas.instance.beingConstructedList.Add(this);
    }

    private void OnDestroy()
    {
        ControlaListas.instance.beingConstructedList.Remove(this);
    }
    private void OnMouseOver()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;

        if (Input.GetMouseButtonDown(1))
        {
            foreach(Skeleton skeleton in UnitSelection.Instance.unitsSelected)
            {
                skeleton.MoveTo(RandomPointAroundBuilding());
                skeleton.buildingTarget = this;
                skeleton.doingTask = true;
                skeleton.ChangeState(skeleton.myStats.buildingState);
            }
        }
    }

    public void Build(float amount)
    {
        progress += amount;
        if(progress >= 1)
        {
            FinishConstruction();
        }
    }

    public Vector3 RandomPointAroundBuilding()
    {
        float angle = Random.Range(0, 2f * Mathf.PI);
        Vector3 pos = transform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;

        if (CheckFreeSpaceAroundPos(pos)) //se estiver livre
        {
            return pos;
        }
        else return RandomPointAroundBuilding();
    }

    bool CheckFreeSpaceAroundPos(Vector3 pos)
    {
        Collider[] colliders = Physics.OverlapSphere(pos, 0.4f, buildingLayer);
        return colliders.Length == 0;
    }

    public void FinishConstruction()
    {
        //PlaceableObject placeableObj = this.gameObject.GetComponent<PlaceableObject>();

        BoxCollider box = GetComponent<BoxCollider>();
        Rigidbody rb = GetComponent<Rigidbody>();

        phantom.SetActive(false);
        finishedObj.SetActive(true);

        Destroy(rb);
        Destroy(box);
        Destroy(this);
    }
}
