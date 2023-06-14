using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    //variaveis necessárias para mover a camera com o mouse
    #region Camera Movement Variables
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 20f;

    float zoomAmount;
    CinemachineVirtualCamera zoom;

    public GameObject currentCamera;

    public CameraStats[] cameras;
    public int activeCameraIndex = 0;
    #endregion


    void Start()
    {
        zoom = currentCamera.GetComponent<CinemachineVirtualCamera>();
        zoom.m_Lens.OrthographicSize = cameras[activeCameraIndex].initialZoom;
    }

    private void Update()
    {
        #region Move Camera Mouse Inputs
        Vector3 pos = currentCamera.transform.position;

        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoomAmount -= scroll * scrollSpeed * 100f * Time.deltaTime;
        zoomAmount = Mathf.Clamp(zoomAmount, cameras[activeCameraIndex].minZoom, cameras[activeCameraIndex].maxZoom);
        zoom.m_Lens.OrthographicSize = zoomAmount;


        pos.x = Mathf.Clamp(pos.x, cameras[activeCameraIndex].panLimitMinX, cameras[activeCameraIndex].panLimitMaxX);
        pos.z = Mathf.Clamp(pos.z, cameras[activeCameraIndex].panLimitMinY, cameras[activeCameraIndex].panLimitMaxY);

        currentCamera.transform.position = pos;
        #endregion
    }



    public void ToggleLocation()
    {
        cameras[activeCameraIndex].gameObject.SetActive(false);

        activeCameraIndex = activeCameraIndex == 1 ? 0 : 1;

        ChangeCamera(cameras[activeCameraIndex]);

        cameras[activeCameraIndex].gameObject.SetActive(true);
    }

    public void ChangeCamera(CameraStats camera)
    {
        zoom = camera.GetComponent<CinemachineVirtualCamera>();
        currentCamera = camera.gameObject;
    }
}
