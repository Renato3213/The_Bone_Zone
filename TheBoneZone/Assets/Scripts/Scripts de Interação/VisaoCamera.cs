using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisaoCamera : MonoBehaviour
{
    public Camera camera; 
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
        if(camera.fieldOfView < minP)
        {
            camera.fieldOfView = minP;
        }

        if(camera.fieldOfView > maxP)
        {
            camera.fieldOfView = maxP;
        }

        if(camera.fieldOfView >= minP && camera.fieldOfView <= maxP)
        {
            camera.fieldOfView += Input.mouseScrollDelta.y * escala * -1;
        }

        //Camera ortogonal.
        if(camera.orthographicSize < minO)
        {
            camera.orthographicSize = minO;
        }

        if(camera.orthographicSize > maxO)
        {
            camera.orthographicSize = maxO;
        }

        if(camera.orthographicSize >= minO && camera.orthographicSize <= maxO)
        {
            camera.orthographicSize += Input.mouseScrollDelta.y * escala * -1;
        }
    }

}
