using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnitSelection : MonoBehaviour
{
    Camera myCam;
    [SerializeField]
    SkeletonWarrior unitSelected;
    public GameObject selectionVisual;

    public GameObject grayscale;

    public LayerMask noGrayScale;
    public LayerMask defaultLayer;


    void Start()
    {
        myCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                SkeletonWarrior unit;
                if (hit.transform.TryGetComponent<SkeletonWarrior>(out unit))
                {

                    ClickSelect(unit);
                }
                else
                {
                    Deselect();
                }

            }
        }
    }

    void ClickSelect(SkeletonWarrior unit)
    {
        unitSelected = unit;
        ChangeLayer(unitSelected.gameObject, "IgnoreGrayScale");
        grayscale.SetActive(true);
        selectionVisual.transform.position = unit.transform.position;
        selectionVisual.SetActive(true);
    }

    void Deselect()
    {
        if(unitSelected == null) return;

        ChangeLayer(unitSelected.gameObject, "Default");
        unitSelected = null;
        grayscale.SetActive(false);
        selectionVisual.SetActive(false);
    }

    void ChangeLayer(GameObject obj, string layerName)
    {
        obj.layer = LayerMask.NameToLayer(layerName);

        foreach (Transform child in obj.transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer(layerName);
        }

    }
}
