using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreateCombatUnit : MonoBehaviour
{
    Camera myCam;


    public Unit unitBeingPlaced;
    public GameObject unitBeingPlacedOBJ;
    public TableTile selectedTile;

    public CombatUnit script;

    public CapsuleCollider _collider;

    public LayerMask layer;

    public ResourceManager resources;
    private void Start()
    {
        myCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CancelCreation();
        }


        if (unitBeingPlacedOBJ == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            PlaceUnit();
        }

        if (CheckIsMouseOverTile(out selectedTile))
        {
            if (selectedTile.placeable)
            {
                unitBeingPlacedOBJ.SetActive(true);
                unitBeingPlacedOBJ.transform.position = selectedTile.transform.position;
            }
            else
            {
                unitBeingPlacedOBJ.SetActive(false);
            }
        }
        else
        {
            unitBeingPlacedOBJ.SetActive(false);
        }


    }


    bool CheckIsMouseOverTile(out TableTile selectedTile)
    {
        RaycastHit hit;
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            TableTile tile;
            if (hit.transform.TryGetComponent<TableTile>(out tile))
            {
                selectedTile = tile;
                return true;
            }

        }
        selectedTile = null;
        return false;
    }


    public void CreateUnit(Unit unitToPlace)
    {
        unitBeingPlaced = unitToPlace;
        unitBeingPlacedOBJ = Instantiate(unitToPlace.prefab, Vector3.zero, Quaternion.Euler(0, 90, 0));

        script = unitBeingPlacedOBJ.GetComponent<CombatUnit>();
        script.enabled = false;

        _collider = unitBeingPlacedOBJ.GetComponent<CapsuleCollider>();
        _collider.enabled = false;
    }
    void PlaceUnit()
    {
        //script.enabled = true;
        //collider.enabled = true;

        //unitBeingPlacedOBJ = null;
        //unitBeingPlaced = null;
        //script = null;
        //collider = null;
        GameObject obj = Instantiate(unitBeingPlaced.prefab, selectedTile.transform.position, Quaternion.Euler(0, 90, 0));
        selectedTile.placeable = false;

        CombatUnit createdScript = obj.GetComponent<CombatUnit>();
        createdScript.myTile = selectedTile;
        resources.UpdateCalcium(-createdScript.price);

        NavMeshAgent agent = obj.GetComponent<NavMeshAgent>();
        agent.enabled = false;

        _collider = obj.GetComponent<CapsuleCollider>();
        _collider.enabled = true;

    }

    void CancelCreation()
    {
        Destroy(unitBeingPlacedOBJ);
        unitBeingPlacedOBJ = null;
        unitBeingPlaced = null;
        script = null;
        _collider = null;
    }


}
