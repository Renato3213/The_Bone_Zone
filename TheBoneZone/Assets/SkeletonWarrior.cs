using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWarrior : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();

    public int attackPower;
    public int health;

    public GameObject particleOrigin;
    public ParticleSystem sys;
    public ParticleSystem.ShapeModule shape;

    public GameObject selectedVisual;
    public GameObject targetVisual;


    public Transform target;

    //private void Start()
    //{
    //    int LayerIgnoreGrayScale = LayerMask.NameToLayer("IgnoreGrayScale");
    //    gameObject.layer = LayerIgnoreGrayScale;

    //    selectedVisual.transform.position = transform.position;
    //    targetVisual.transform.position = target.position;
    //    targetVisual.transform.LookAt(transform.position);

    //    particleOrigin.transform.position = target.GetChild(0).position;
    //    particleOrigin.transform.LookAt(transform.position);

    //    float distance = Vector3.Distance(transform.position, target.position);

    //    shape = sys.shape;

    //    shape.position = new Vector3(0,0, distance - 0.9f);
    //}

}
