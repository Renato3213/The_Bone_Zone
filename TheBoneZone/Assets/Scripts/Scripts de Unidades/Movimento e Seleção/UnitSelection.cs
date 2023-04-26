using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{

    public List<Skeleton> unitList = new List<Skeleton>();
    public List<Skeleton> unitsSelected = new List<Skeleton>();

    static UnitSelection _instance;
    public static UnitSelection Instance { get { return _instance; } }

    void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ClickSelect(Skeleton unitToAdd)
    {
        DeselectAll();
        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.GetComponent<UnitMovement>().enabled = true;
    }

    public void ShiftClickSelect(Skeleton unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
        else
        {
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            unitToAdd.GetComponent<UnitMovement>().enabled = false;
            unitsSelected.Remove(unitToAdd);
        }
    }

    public void DragSelect(Skeleton unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
    }

    public void DeselectAll()
    {
        foreach(var unit in unitsSelected)
        {
            unit.transform.GetChild(0).gameObject.SetActive(false);
            unit.GetComponent<UnitMovement>().enabled = false;
        }
        unitsSelected.Clear();
    }

    public void Deselect(Skeleton unitToDeselect)
    {
        unitToDeselect.transform.GetChild(0).gameObject.SetActive(false);
        unitToDeselect.GetComponent<UnitMovement>().enabled = false;
        unitsSelected.Remove(unitToDeselect);
    }
}
