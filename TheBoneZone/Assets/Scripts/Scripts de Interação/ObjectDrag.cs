using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    Vector3 offset;

     /*void OnMouseDown()
    {
        offset = transform.position - BuildingSystem.GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        Vector3 pos = BuildingSystem.GetMouseWorldPosition() + offset;
        transform.position = BuildingSystem.instance.SnapCoordinateToGrid(pos);
    }*/

    private void FixedUpdate()
    {

        Vector3 pos = BuildingSystem.GetMouseWorldPosition();
        transform.position = BuildingSystem.instance.SnapCoordinateToGrid(pos);
    }
}
