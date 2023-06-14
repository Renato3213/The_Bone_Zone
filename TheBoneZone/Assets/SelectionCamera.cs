using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCamera : MonoBehaviour
{
    public CinemachineVirtualCamera mainCam;

    Camera thisCam;

    private void Awake()
    {
        thisCam = GetComponent<Camera>();
    }
    void Update()
    {
        thisCam.orthographicSize = mainCam.m_Lens.OrthographicSize;
    }
}
