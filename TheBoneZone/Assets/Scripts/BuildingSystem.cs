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

    public GameObject turret1;
    public GameObject turret2;
    public GameObject Fazenda;
    public GameObject Mercado;

    PlaceableObject objToPlace;

    void Awake()
    {
        instance = this;
        grid = gridLayout.GetComponent<Grid>();
        myCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !GameManager.instance.onCenter)
        {
            if(GameManager.instance.totalCalcio >= 10)
            {
                GameManager.instance.AtualizaMoedas(-10);
                InitializeWithObject(turret1);
            }
        }
        
        else if (Input.GetKeyDown(KeyCode.E) && GameManager.instance.onCenter)
        {
            InitializeWithObject(Fazenda);
        }
        else if (Input.GetKeyDown(KeyCode.R) && GameManager.instance.onCenter)
        {
            InitializeWithObject(Mercado);
        }
        if (!objToPlace)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            objToPlace.Rotate();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanBePlaced(objToPlace))
            {
                objToPlace.Place();
                Vector3Int start = gridLayout.WorldToCell(objToPlace.GetStartPosition());
                TakeArea(start, objToPlace.size);
            }
            else
            {
                Destroy(objToPlace.gameObject);
            }
        }
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit))
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
        Vector3 position = SnapCoordinateToGrid(GetMouseWorldPosition());

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        objToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
    }

    bool CanBePlaced(PlaceableObject placeable)
    {
        BoundsInt area = new BoundsInt();
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

        return true;
    }

    public void TakeArea(Vector3Int start, Vector3Int size)
    {
        mainTilemap.BoxFill(start, whiteTile, start.x, start.y, start.x + size.x, start.y + size.y);
    }
}
