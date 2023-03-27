using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SpellsTree
{
    /*
    [SerializeField] bool spellAbruptDecay;
    [SerializeField] bool spellBoneCarving;
    [SerializeField] bool spellBonePlating;
    [SerializeField] bool spellBoneTransmutation;
    [SerializeField] bool spellDarkblast;
    [SerializeField] bool spellFog;
    [SerializeField] bool spellMoreBones;
    [SerializeField] bool spellNec_romantic;
    [SerializeField] bool spellReadTheBones;
    [SerializeField] bool spellStrongerBones;
    [SerializeField] bool spellTheBoneZone;
    */

    //Nível da magia.
    public int level;
    //Custo da magia.
    public float cost;
    //Descrição da magia.
    public Text description;

    //Obriga a implementação do método nos que herdam.
    public abstract void UnlockSpell();

    //Retorna o custo da magia.
    public float GetCost()
    {
        return cost;
    }

    //Retorna a descrição da magia.
    public Text GetDescription()
    {
        return description;
    }
}
