using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TechTree
{
    /*
    [SerializeField] bool researchAdvancedNecromancy;
    [SerializeField] bool researchAdventuresGuild;
    [SerializeField] bool researchAgricultureBone;
    [SerializeField] bool researchBasicNecromancy;
    [SerializeField] bool researchBetterTools;
    [SerializeField] bool researchBlacksmith;
    [SerializeField] bool researchCrypts;
    [SerializeField] bool researchDairyProducts;
    [SerializeField] bool researchDarkArts;
    [SerializeField] bool researchGreveyards;
    [SerializeField] bool researchGuildDiscount;
    [SerializeField] bool researchIndustry;
    [SerializeField] bool researchMagicUniversity;
    [SerializeField] bool researchMarkets;
    [SerializeField] bool researchMausoleums;
    [SerializeField] bool researchMilitaryCamp;
    [SerializeField] bool researchMilitaryIndustrialComplex;
    [SerializeField] bool researchPhDInNecromancy;
    [SerializeField] bool researchPlantations;
    [SerializeField] bool researchPubs;
    */

    //Custo da pesquisa.
    public float cost;
    //Descrição da pesquisa.
    public Text description;

    //Obriga a implementação do método nos que herdam.
    public abstract void UnlockResearch();

    //Retorna o custo da pesquisa.
    public float GetCost()
    {
        return cost;
    }

    //Retorna a descrição da pesquisa.
    public Text GetDescription()
    {
        return description;
    }
}
