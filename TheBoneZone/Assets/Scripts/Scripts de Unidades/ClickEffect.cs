using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    void Awake()
    {
        Destroy(this.gameObject, 1);
    }

}
