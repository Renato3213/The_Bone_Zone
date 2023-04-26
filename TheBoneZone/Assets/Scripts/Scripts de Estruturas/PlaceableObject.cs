using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public bool placed { get; private set; }
    [SerializeField]
    public bool canBePlaced; 

    public GameObject phantom, obj;

    public Material phantomMat;
    public float custo;
   

    void Start()
    {
        phantomMat.color = new Color32(180, 255, 0, 180);
        GetComponent<UnderConstruction>().enabled = false;
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(0, 90, 0));
    }

    public virtual void Place()
    {
        bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();

        if (isOverUI) return;

        GameObject place = Instantiate(gameObject, transform.position, transform.rotation);
        PlaceableObject placeableObj = place.GetComponent<PlaceableObject>();

        ObjectDrag drag = place.GetComponent<ObjectDrag>();
        Destroy(drag);

        place.GetComponent<UnderConstruction>().enabled = true;

        placeableObj.placed = true;
        GameManager.instance.AtualizaCalcio(-custo);
        
    }

    public void CancelBuilding()
    {
        Destroy(this.gameObject);
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
