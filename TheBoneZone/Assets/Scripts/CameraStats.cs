using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStats : MonoBehaviour , IDataPersistance
{
    public float panLimitMinY, panLimitMaxY, panLimitMinX, panLimitMaxX;

    public float minZoom;
    public float maxZoom;
    public float initialZoom;

    public void SaveData(ref SceneData data)
    {
        throw new System.NotImplementedException();
    }
}
