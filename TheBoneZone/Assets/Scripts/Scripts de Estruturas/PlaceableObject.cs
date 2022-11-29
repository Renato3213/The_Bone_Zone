using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public bool placed { get; private set; }
    [SerializeField]
    public bool canBePlaced; //{ get; private set; }
    public Vector3Int size { get; private set; }
    Vector3[] Vertices;

    public GameObject phantom, obj;

    public Material phantomMat;
    public float custo;
   

    void Start()
    {
        phantomMat.color = new Color32(180, 255, 0, 180);
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(0, 90, 0));
    }

    public virtual void Place()
    {
        GameObject place = Instantiate(gameObject, transform.position, transform.rotation);
        PlaceableObject placeableObj = place.GetComponent<PlaceableObject>();

        ObjectDrag drag = place.GetComponent<ObjectDrag>();
        BoxCollider box = place.GetComponent<BoxCollider>();
        Rigidbody rb = place.GetComponent<Rigidbody>();

        Destroy(rb);
        Destroy(box);
        Destroy(drag);

        placeableObj.placed = true;
        GameManager.instance.AtualizaCalcio(-custo);
        placeableObj.phantom.SetActive(false);
        placeableObj.obj.SetActive(true);
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            canBePlaced = false;
            phantomMat.color = new Color32(255, 0, 0, 180);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if(GameManager.instance.Calcio > custo)
            {
                canBePlaced = true;
                phantomMat.color = new Color32(180, 255, 0, 180);
            }
        }
    }
}
