using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnitSelection : MonoBehaviour , ICombatObserver
{
    Camera myCam;
    [SerializeField]
    SkeletonWarrior unitSelected;
    public GameObject selectionVisual;

    public GameObject grayscale;

    public Transform[] targetVisuals;
    public Transform[] particleOrigins;

    public LayerMask noGrayScale;
    public LayerMask defaultLayer;

    public bool startedBattle;
    private void Start()
    {
        myCam = Camera.main;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !startedBattle)
        {
            ClickEvent();
        }
    }

    void ClickEvent()
    {
        RaycastHit hit;
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            SkeletonWarrior unit;
            Enemy enemyUnit;
            if (hit.transform.TryGetComponent<SkeletonWarrior>(out unit))
            {
                ClickSelect(unit);
            }
            else if (hit.transform.TryGetComponent<Enemy>(out enemyUnit))
            {
                TryAddTarget(enemyUnit);
            }

            else
            {
                Deselect();
            }
            //Debug.Log(hit.transform.gameObject.name);
        }
    }

    void TryAddTarget(Enemy enemyToAdd)
    {
        if (unitSelected == null) return;

        if (!unitSelected.targetsList.Contains(enemyToAdd) && unitSelected.targetsList.Count < 3)
        {
            unitSelected.targetsList.Add(enemyToAdd);
        }
        else
        {
            Debug.Log("aa");
            ChangeLayerOfUnit(enemyToAdd.gameObject, "Default");
            DeactivateAllTargetVisuals();
            unitSelected.targetsList.Remove(enemyToAdd);
        }

        ShowTargets(unitSelected);
    }


    void ShowTargets(SkeletonWarrior skeleton)
    {
        if (skeleton.targetsList.Count == 0) return;

        foreach (CombatUnit target in skeleton.targetsList)
        {
            ChangeLayerOfUnit(target.gameObject, "IgnoreGrayScale");
        }


        Transform from = skeleton.transform; //inicio do pontilhado
        Transform to = null; //fim do pontilhado


        for (int i = 0; i < skeleton.targetsList.Count; i++)
        {
            to = skeleton.targetsList[i].transform;
            ActivateTargetVisuals(from, to, i);
            from = skeleton.targetsList[i].transform;
        }
    }


    void ActivateTargetVisuals(Transform from, Transform to, int index)
    {
        targetVisuals[index].gameObject.SetActive(true);
        particleOrigins[index].gameObject.SetActive(true);

        targetVisuals[index].position = to.position;
        targetVisuals[index].LookAt(from.position);

        particleOrigins[index].position = to.position;
        particleOrigins[index].LookAt(from.position);

        float distance = Vector3.Distance(from.position, to.position);

        ParticleSystem ps = particleOrigins[index].GetComponentInChildren<ParticleSystem>();
        ParticleSystem.ShapeModule shape = ps.shape;

        shape.position = new Vector3(0, 0, distance - 0.9f);
    }

    void DeactivateAllTargetVisuals()
    {
        foreach (Transform visual in targetVisuals)
        {
            visual.gameObject.SetActive(false);
        }
        foreach (Transform visual in particleOrigins)
        {
            visual.gameObject.SetActive(false);
        }
    }

    void ClickSelect(SkeletonWarrior unit)
    {
        Deselect();
        unitSelected = unit;
        ShowTargets(unit);
        ChangeLayerOfUnit(unitSelected.gameObject, "IgnoreGrayScale");
        grayscale.SetActive(true);
        selectionVisual.transform.position = unit.transform.position;
        selectionVisual.SetActive(true);
    }

    void Deselect()
    {
        if (unitSelected == null) return;

        DeactivateAllTargetVisuals();
        ChangeLayerOfUnit(unitSelected.gameObject, "Default");
        foreach (CombatUnit enemy in unitSelected.targetsList)
        {
            ChangeLayerOfUnit(enemy.gameObject, "Default");
        }
        unitSelected = null;
        grayscale.SetActive(false);
        selectionVisual.SetActive(false);
    }

    void ChangeLayerOfUnit(GameObject obj, string layerName)
    {
        obj.layer = LayerMask.NameToLayer(layerName);

        foreach (Transform child in obj.transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer(layerName);
        }

    }

    public void NotifyStart()
    {
        startedBattle = true;
    }
}
