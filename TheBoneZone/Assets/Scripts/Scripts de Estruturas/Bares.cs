using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class PubData
{
    public Vector3 position;
    public Vector3 rotation;
}

public class PubAdapter : PubData
{
    public PubAdapter(Bares pub)
    {
        position = pub.transform.position;
        rotation = pub.transform.rotation.eulerAngles;
    }
}

public class Bares : MonoBehaviour, IDataPersistance
{
    public TextMeshProUGUI slots;
    public List<Skeleton> descansandoAqui = new List<Skeleton>();
    public Transform entrada, saida;
    public int limiteEsqueletos = 5;

    [SerializeField]
    StructureFlyweight myStats;

    public GameObject myInterface;

    public float multiplier = 5;

    public int myId;
    void Awake()
    {
        ControlaListas.instance.pubsList.Add(this);
        myId = ControlaListas.instance.pubsList.IndexOf(this);
    }
    void Start()
    {
        SaveGame.instance.persistentObjects.Add(this);
    }

    void OnMouseOver()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;
        if (Input.GetMouseButtonDown(1))
        {
            ChamarEsqueletos();
        }
    }

    void OnMouseDown()
    {
        GameManager.instance.UpdateActiveInterface(myInterface);
        AtualizaInterface();
    }

    void ChamarEsqueletos()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;


        if (descansandoAqui.Count < myStats.grinderSkeletonLimit)
        {
            SendSkeletonToPub();

            ChamarEsqueletos();
        }

    }

    void SendSkeletonToPub()
    {
        Skeleton skeleton = UnitSelection.Instance.unitsSelected[0];

        skeleton.MoveTo(entrada.position);
        skeleton.pubTarget = this;
        skeleton.doingTask = true;
        skeleton.isResting = true;
        UnitSelection.Instance.Deselect(skeleton);
    }


    public void AtualizaInterface()
    {
        slots.text = "" + descansandoAqui.Count + "/" + limiteEsqueletos;
    }

    public void LiberaEsqueleto(Skeleton esqueleto)
    {
        descansandoAqui[0].transform.position = saida.position;
        descansandoAqui[0].ResetSkeleton();
        descansandoAqui.RemoveAt(0);
        AtualizaInterface();
    }

    public void SaveData(ref SceneData data)
    {
        data.pubs.Add(new PubAdapter(this));
    }
}
