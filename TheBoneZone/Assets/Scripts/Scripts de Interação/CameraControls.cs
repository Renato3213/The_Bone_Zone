using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    //variaveis necessárias para o funcionamento da função ChangeLocation
    #region ChangeLocation Variables
    public enum Location { Center, North, South, West, East }

    public Location currentLocation;

    public GameObject CameraNorth, CameraSouth, CameraWest, CameraEast;

    public GameObject northButton, southButton, westButton, eastButton;

    public GameObject InterfaceTowerDefense, InterfaceCity;
    #endregion 

    //variaveis necessárias para mover a camera com o mouse
    #region Camera Movement Variables
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public float panLimitMinY, panLimitMaxY, panLimitX;

    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;

    public GameObject CenterCamera;
    #endregion


    void Start()
    {
        GameManager.instance.onCenter = true;
        currentLocation = Location.Center;
        CameraNorth.SetActive(false);
        CameraSouth.SetActive(false);
        CameraWest.SetActive(false);
        CameraEast.SetActive(false);
    }

    private void Update()
    {
        #region Keyboard ChangeLocation Inputs
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeLocation("North");
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeLocation("South");
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeLocation("West");
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeLocation("East");
        }
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
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimitX, panLimitX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, panLimitMinY, panLimitMaxY);

        if(GameManager.instance.onCenter) CenterCamera.transform.position = pos;
        #endregion
    }

    public void ChangeLocation(string dir)//anda com a camera para a direção do input
    {

        if (currentLocation == Location.Center)
        {
            
            switch (dir)
            {
                case "North":
                    CameraNorth.SetActive(true);
                    currentLocation = Location.North;
                    //northButton.SetActive(false);
                    break;
                case "South":
                    CameraSouth.SetActive(true);
                    currentLocation = Location.South;
                    //southButton.SetActive(false);
                    GameManager.instance.onCenter = false;
                    break;
                case "West":
                    CameraWest.SetActive(true);
                    currentLocation = Location.West;
                    //westButton.SetActive(false);
                    GameManager.instance.onCenter = false;
                    break;
                case "East":
                    CameraEast.SetActive(true);
                    currentLocation = Location.East;
                    //eastButton.SetActive(false);
                    GameManager.instance.onCenter = false;
                    break;
            }

        }
        else if (currentLocation == Location.North)
        {
            switch (dir)
            {
                case "South":
                    CameraNorth.SetActive(false);
                    currentLocation = Location.Center;
                    //northButton.SetActive(true);
                    //southButton.SetActive(true);
                    //westButton.SetActive(true);
                    //eastButton.SetActive(true);
                    break;
                case "West":
                    CameraWest.SetActive(true);
                    CameraNorth.SetActive(false);
                    currentLocation = Location.West;
                    //northButton.SetActive(true);
                    //westButton.SetActive(false);
                    break;
                case "East":
                    CameraEast.SetActive(true);
                    CameraNorth.SetActive(false);
                    currentLocation = Location.East;
                    //northButton.SetActive(true);
                    //eastButton.SetActive(false);
                    break;
            }
        }
        else if (currentLocation == Location.South)
        {
            switch (dir)
            {
                case "North":
                    CameraSouth.SetActive(false);
                    currentLocation = Location.Center;
                    //northButton.SetActive(true);
                    //southButton.SetActive(true);
                    //westButton.SetActive(true);
                    //eastButton.SetActive(true);
                    break;
                case "West":
                    CameraWest.SetActive(true);
                    CameraSouth.SetActive(false);
                    currentLocation = Location.West;
                    //westButton.SetActive(false);
                    //southButton.SetActive(true);
                    break;
                case "East":
                    CameraEast.SetActive(true);
                    CameraSouth.SetActive(false);
                    currentLocation = Location.East;
                    //eastButton.SetActive(false);
                    //southButton.SetActive(true);
                    break;
            }
        }
        else if (currentLocation == Location.West)
        {
            switch (dir)
            {
                case "East":
                    CameraWest.SetActive(false);
                    currentLocation = Location.Center;
                    //northButton.SetActive(true);
                    //southButton.SetActive(true);
                    //westButton.SetActive(true);
                    //eastButton.SetActive(true);
                    break;
                case "North":
                    CameraWest.SetActive(false);
                    CameraNorth.SetActive(true);
                    currentLocation = Location.North;
                    //northButton.SetActive(false);
                    //westButton.SetActive(true);
                    break;
                case "South":
                    CameraWest.SetActive(false);
                    CameraSouth.SetActive(true);
                    currentLocation = Location.South;
                    //southButton.SetActive(false);
                    //westButton.SetActive(true);
                    break;
            }
        }
        else
        {
            switch (dir)
            {
                case "West":
                    CameraEast.SetActive(false);
                    currentLocation = Location.Center;
                    //northButton.SetActive(true);
                    //southButton.SetActive(true);
                    //westButton.SetActive(true);
                    //eastButton.SetActive(true);
                    break;
                case "North":
                    CameraNorth.SetActive(true);
                    CameraEast.SetActive(false);
                    currentLocation = Location.North;
                    //northButton.SetActive(false);
                    //eastButton.SetActive(true);
                    break;
                case "South":
                    CameraSouth.SetActive(true);
                    CameraEast.SetActive(false);
                    currentLocation = Location.South;
                    //southButton.SetActive(false);
                    //eastButton.SetActive(true);
                    break;
            }
        }

        if (currentLocation == Location.Center)
        {
            InterfaceTowerDefense.SetActive(false);
            InterfaceCity.SetActive(true);
            GameManager.instance.onCenter = true;
            CenterCamera.transform.position = new Vector3(0, 10, -7);
            GameManager.instance.onCenter = true;
        }

        else
        {
            InterfaceTowerDefense.SetActive(true);
            InterfaceCity.SetActive(false);
            GameManager.instance.onCenter = false;
        }


    }
}
