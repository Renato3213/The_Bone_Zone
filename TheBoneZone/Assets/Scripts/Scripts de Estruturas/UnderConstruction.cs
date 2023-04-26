using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderConstruction : MonoBehaviour
{
    public GameObject phantom, finishedObj;

    public float progress;

    public float radius;

    private void OnMouseOver()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("a");
            foreach(Skeleton skeleton in UnitSelection.Instance.unitsSelected)
            {
                skeleton.MoveTo(RandomPointAroundBuilding());
                skeleton.buildingTarget = this;
                skeleton.doingTask = true;
                skeleton.currentState = skeleton.buildingState;
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

    private void OnMouseDown()
    {
        Debug.DrawRay(transform.position, RandomPointAroundBuilding(), Color.blue, 3f);
    }

    public Vector3 RandomPointAroundBuilding()
    {
        float angle = Random.Range(0, 2f * Mathf.PI);
        return transform.position + new Vector3 (Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
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