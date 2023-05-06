using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisaoCamera : MonoBehaviour
{
    public Camera myCamera; 
    public float escala;
    public float minO = 10;
    public float maxO = 20;
    public float minP = 30;
    public float maxP = 60;

    void Awake()
    {
        escala = 0.5f;
    }

    void Update()
    {
        //Camera pespectiva.
        if(myCamera.fieldOfView < minP)
        {
            myCamera.fieldOfView = minP;
        }

        if(myCamera.fieldOfView > maxP)
        {
            myCamera.fieldOfView = maxP;
        }

        if(myCamera.fieldOfView >= minP && myCamera.fieldOfView <= maxP)
        {
            myCamera.fieldOfView += Input.mouseScrollDelta.y * escala * -1;
        }

        //Camera ortogonal.
        if(myCamera.orthographicSize < minO)
        {
            myCamera.orthographicSize = minO;
        }

        if(myCamera.orthographicSize > maxO)
        {
            myCamera.orthographicSize = maxO;
        }

        if(myCamera.orthographicSize >= minO && myCamera.orthographicSize <= maxO)
        {
            myCamera.orthographicSize += Input.mouseScrollDelta.y * escala * -1;
        }
    }

}
