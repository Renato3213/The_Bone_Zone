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
            OpenBuidingInterface();
        }

        #endregion
        #region Place Inputs

        if (!objToPlace) return;
       

        if (Input.GetKeyDown(KeyCode.Return)) objToPlace.Rotate();
       
        else if (Input.GetMouseButtonDown(0))
        {
            if (CanBePlaced(objToPlace))
            {
                objToPlace.Place();
                Vector3Int start = gridLayout.WorldToCell(objToPlace.GetStartPosition());
                TakeArea(start, objToPlace.size);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            GameManager.instance.building = false;
            Destroy(objToPlace.gameObject);
        }

        #endregion

    }

    public void OpenBuidingInterface()//pra eu poder chamar de um botão no jogo também
    {
        if (GameManager.instance.onCenter)
        {
            BuildInterface.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            BuildInterface.transform.GetChild(1).gameObject.SetActive(true);
        }
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

    static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }

        return array;
    }

    public void InitializeWithObject(GameObject prefab)
    {
        GameManager.instance.building = true;
        if(objToPlace != null) Destroy(objToPlace.gameObject);

        Vector3 position = SnapCoordinateToGrid(GetMouseWorldPosition());

        GameObject obj = Instantiate(prefab, position, Quaternion.Euler(0, 45, 0));
        objToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
    }

    bool CanBePlaced(PlaceableObject placeable)
    {
        /*BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(objToPlace.GetStartPosition());
        area.size = placeable.size;

        TileBase[] baseArray = GetTilesBlock(area, mainTilemap);

        foreach (var b in baseArray)
        {
            if(b == whiteTile)
            {
                return false;
            }
        }

        return true;*/

        return placeable.canBePlaced;
    }

    public void TakeArea(Vector3Int start, Vector3Int size)
    {
        mainTilemap.BoxFill(start, whiteTile, start.x, start.y, start.x + size.x, start.y + size.y);
    }
}
