using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    //variaveis necessárias para o funcionamento da função ChangeLocation
    #region ChangeLocation Variables
    //public enum Location { Center, North, South, West, East }

    //public Location currentLocation;

    //public GameObject CameraNorth, CameraSouth, CameraWest, CameraEast;

    //public GameObject northButton, southButton, westButton, eastButton;

    //public GameObject InterfaceTowerDefense, InterfaceCity;
    #endregion 

    //variaveis necessárias para mover a camera com o mouse
    #region Camera Movement Variables
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public float panLimitMinY, panLimitMaxY, panLimitX;

    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;

    float zoomAmount = 5f;
    CinemachineVirtualCamera zoom;

    public GameObject CenterCamera;
    #endregion


    void Start()
    {
        zoom = CenterCamera.GetComponent<CinemachineVirtualCamera>();
        //GameManager.instance.onCenter = true;
        //currentLocation = Location.Center;
        //CameraNorth.SetActive(false);
        //CameraSouth.SetActive(false);
        //CameraWest.SetActive(false);
        //CameraEast.SetActive(false);
    }

    private void Update()
    {
        #region Keyboard ChangeLocation Inputs
        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    ChangeLocation("North");
        //}
        //else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    ChangeLocation("South");
        //}
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    ChangeLocation("West");
        //}
        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    ChangeLocation("East");
        //}
        #endregion

        #region Move Camera Mouse Inputs
        Vector3 pos = CenterCamera.transform.position;

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
        zoomAmount = Mathf.Clamp(zoomAmount, minY, maxY);
        zoom.m_Lens.OrthographicSize = zoomAmount;


        pos.x = Mathf.Clamp(pos.x, -panLimitX, panLimitX);
        pos.z = Mathf.Clamp(pos.z, panLimitMinY, panLimitMaxY);

        CenterCamera.transform.position = pos;
        #endregion
    }



    public void ToggleLocation()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
