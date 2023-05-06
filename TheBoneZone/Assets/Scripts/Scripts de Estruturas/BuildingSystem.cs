using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem instance;

    public GridLayout gridLayout;
    Grid grid;
    [SerializeField] Tilemap mainTilemap;
    [SerializeField] TileBase whiteTile;
    static Camera myCam;
    public GameObject BuildInterface;


    PlaceableObject objToPlace;

    void Awake()
    {
        instance = this;
        grid = gridLayout.GetComponent<Grid>();
        myCam = Camera.main;
    }

    void Update()
    {
        #region Open Building Interface

        if (Input.GetKeyDown(KeyCode.B)) //B de Build
        {
            GameManager.instance.UpdateActiveInterface(BuildInterface);
        }

        #endregion
        #region Place Inputs

        if (!objToPlace) return;


        if (Input.GetKeyDown(KeyCode.R)) objToPlace.Rotate();

        else if (Input.GetMouseButtonDown(0))
        {
            if (CanBePlaced(objToPlace))
            {
                objToPlace.Place();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Destroy(objToPlace.gameObject);
        }

        #endregion

    }

    public void OpenBuidingInterface()
    {

        BuildInterface.transform.GetChild(0).gameObject.SetActive(true);

    }
    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point;
        }
        else
        {
            return Vector3.zero;
        }

    }

    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
    }

    public void InitializeWithObject(GameObject prefab)
    {
        if (objToPlace != null) Destroy(objToPlace.gameObject);

        Vector3 position = new Vector3(0, 0, 0);
        //SnapCoordinateToGrid(GetMouseWorldPosition());

        GameObject obj = Instantiate(prefab, position, prefab.transform.rotation);
        objToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
    }

    bool CanBePlaced(PlaceableObject placeable)
    {
        return placeable.canBePlaced;
    }

}
