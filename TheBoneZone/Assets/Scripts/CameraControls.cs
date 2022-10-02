using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public enum Location { Center, North, South, West, East}

    public Location currentLocation;

    public GameObject CameraNorth, CameraSouth, CameraWest, CameraEast;

    public GameObject northButton, southButton, westButton, eastButton;

    public bool onCenter;

    void Start()
    {
        currentLocation = Location.Center;
        CameraNorth.SetActive(false);
        CameraSouth.SetActive(false);
        CameraWest.SetActive(false);
        CameraEast.SetActive(false);
    }

    public void ChangeLocation(string dir)
    {
        if (currentLocation == Location.Center)
        {
            onCenter = true;
            switch (dir)
            {
               case "North":
                    CameraNorth.SetActive(true);
                    currentLocation = Location.North;
                    northButton.SetActive(false);
                    break;
                case "South":
                    CameraSouth.SetActive(true);
                    currentLocation = Location.South;
                    southButton.SetActive(false);
                    break;
                case "West":
                    CameraWest.SetActive(true);
                    currentLocation = Location.West;
                    westButton.SetActive(false);
                    break;
                case "East":
                    CameraEast.SetActive(true);
                    currentLocation = Location.East;
                    eastButton.SetActive(false);
                    break;
            }

        }
        else if(currentLocation == Location.North)
        {
            switch (dir)
            {
                case "South":
                    CameraNorth.SetActive(false);
                    currentLocation = Location.Center;
                    northButton.SetActive(true);
                    southButton.SetActive(true);
                    westButton.SetActive(true);
                    eastButton.SetActive(true);
                    break;
                case "West":
                    CameraWest.SetActive(true);
                    CameraNorth.SetActive(false);
                    currentLocation = Location.West;
                    northButton.SetActive(true);
                    westButton.SetActive(false);
                    break;
                case "East":
                    CameraEast.SetActive(true);
                    CameraNorth.SetActive(false);
                    currentLocation = Location.East;
                    northButton.SetActive(true);
                    eastButton.SetActive(false);
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
                    northButton.SetActive(true);
                    southButton.SetActive(true);
                    westButton.SetActive(true);
                    eastButton.SetActive(true);
                    break;
                case "West":
                    CameraWest.SetActive(true);
                    CameraSouth.SetActive(false);
                    currentLocation = Location.West;
                    westButton.SetActive(false);
                    southButton.SetActive(true);
                    break;
                case "East":
                    CameraEast.SetActive(true);
                    CameraSouth.SetActive(false);
                    currentLocation = Location.East;
                    eastButton.SetActive(false);
                    southButton.SetActive(true);
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
                    northButton.SetActive(true);
                    southButton.SetActive(true);
                    westButton.SetActive(true);
                    eastButton.SetActive(true);
                    break;
                case "North":
                    CameraWest.SetActive(false);
                    CameraNorth.SetActive(true);
                    currentLocation = Location.North;
                    northButton.SetActive(false);
                    westButton.SetActive(true);
                    break;
                case "South":
                    CameraWest.SetActive(false);
                    CameraSouth.SetActive(true);
                    currentLocation = Location.South;
                    southButton.SetActive(false);
                    westButton.SetActive(true);
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
                    northButton.SetActive(true);
                    southButton.SetActive(true);
                    westButton.SetActive(true);
                    eastButton.SetActive(true);
                    break;
                case "North":
                    CameraNorth.SetActive(true);
                    CameraEast.SetActive(false);
                    currentLocation = Location.North;
                    northButton.SetActive(false);
                    eastButton.SetActive(true);
                    break;
                case "South":
                    CameraSouth.SetActive(true);
                    CameraEast.SetActive(false);
                    currentLocation = Location.South;
                    southButton.SetActive(false);
                    eastButton.SetActive(true);
                    break;
            }
        }


    }
}
