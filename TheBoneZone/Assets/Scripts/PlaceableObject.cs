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

    public float custo;

    void GotColliderVertexPositionsLocal() 
    {
        BoxCollider b = GetComponent<BoxCollider>();
        Vertices = new Vector3[4];
        Vertices[0] = b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f;
        Vertices[1] = b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f;
        Vertices[2] = b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f;
        Vertices[3] = b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f;
    }

    void CalculateSizeInCells()
    {
        Vector3Int[] vertices = new Vector3Int[Vertices.Length];

        for(int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldPos = transform.TransformPoint(vertices[i]);
            vertices[i] = BuildingSystem.instance.gridLayout.WorldToCell(worldPos);
        }

        size = new Vector3Int(Mathf.Abs((vertices[0] - vertices[1]).x), Mathf.Abs((vertices[0] - vertices[3]).y), 1);
    }

    public Vector3 GetStartPosition()
    {
        return transform.TransformPoint(Vertices[0]);
    }

    void Start()
    {
        GotColliderVertexPositionsLocal();
        CalculateSizeInCells();
    }

    private void Update()
    {
       
    }
    public void Rotate()
    {
        transform.Rotate(new Vector3(0, 90, 0));
        size = new Vector3Int(size.y, size.x, 1);

        Vector3[] vertices = new Vector3[Vertices.Length];
        for(int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[(i + 1) % Vertices.Length];
        }

        Vertices = vertices;
    }

    public virtual void Place()
    {
        GameObject place = Instantiate(gameObject, transform.position, transform.rotation);
        ObjectDrag drag = place.GetComponent<ObjectDrag>();
        BoxCollider collider = place.GetComponent<BoxCollider>();
        PlaceableObject placeableObj = place.GetComponent<PlaceableObject>();
        Destroy(drag);
        collider.isTrigger = false;

        placeableObj.placed = true;
        GameManager.instance.AtualizaCalcio(-custo);
        placeableObj.phantom.SetActive(false);
        placeableObj.obj.SetActive(true);
        //phantom.SetActive(false);
        //obj.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            canBePlaced = false;
            Renderer mat = phantom.GetComponent<Renderer>();
            mat.material.color = new Color32(255, 0, 0, 180);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if(GameManager.instance.Calcio > custo)
            {
                canBePlaced = true;
                MeshRenderer mat = phantom.GetComponent<MeshRenderer>();
                mat.material.color = new Color32(180, 255, 0, 180);
            }
        }
    }
}
