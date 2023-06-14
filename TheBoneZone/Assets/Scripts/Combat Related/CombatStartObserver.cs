using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStartObserver : MonoBehaviour
{
    public static CombatStartObserver instance;

    public List<CombatUnit> unitList;

    private void Start()
    {
        instance= this;
    }

    public void Notify()
    {
        foreach (CombatUnit unit in unitList)
        {
            unit.transform.GetComponent<ICombatObserver>()?.NotifyStart();
        }
    }
}
