using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadType : MonoBehaviour
{   
    //Corpo do esqueleto.
    [SerializeField]GameObject skeleton;
    //Lista das cabeças possíveis.
    [SerializeField]GameObject[] head;
    
    void Awake()
    {   
        //Sorteia a cabeça que o esqueleto terá.
        int randomHead = Random.Range(0, head.Length - 1);
        //Cria a cabeça no esqueleto.
        Instantiate(head[randomHead], skeleton.transform.position + new Vector3(0, .5f, 0), skeleton.transform.rotation, skeleton.transform);
    }
}
