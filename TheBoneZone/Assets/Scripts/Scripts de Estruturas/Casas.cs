using System;
using UnityEngine;

[Serializable]
public class HouseData
{
    public Vector3 position;
    public Vector3 rotation;
}

public class HouseAdapter : HouseData
{
    public HouseAdapter(Casas house)
    {
        position = house.transform.position;
        rotation = house.transform.rotation.eulerAngles;
    }
}
public class Casas : MonoBehaviour, IDataPersistance
{

    public StructureFlyweight myStats;

    public void SaveData(ref SceneData data)
    {
        data.houses.Add(new HouseAdapter(this));
    }

    void Awake()
    {
        ControlaListas.instance.housesList.Add(this); 
        GameManager.instance.maxSkeletons += myStats.houseAditionalSlots;
        GameManager.instance.UpdateSkeletonCount();
    }

    void Start()
    {
        SaveGame.instance.persistentObjects.Add(this);
    }
}
