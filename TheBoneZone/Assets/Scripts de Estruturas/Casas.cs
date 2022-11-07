using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casas : MonoBehaviour
{
    void Awake()
    {
        GameManager.instance.maxSkeletons += 15;
        GameManager.instance.UpdateSkeletonCount();
    }

}
