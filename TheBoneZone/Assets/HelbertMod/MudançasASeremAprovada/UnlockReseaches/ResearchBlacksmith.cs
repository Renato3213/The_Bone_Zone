using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchBlacksmith : TechTree
{
    //Inicializa os atributos da pesquisa.
    public ResearchBlacksmith()
    {
        //Custo da pesquisa.
        cost = 1000;
        //Texto da descrição: Pode criar Soldados Esqueletos.
        description.text = "Can create Soldier Skeletons.";
    }

    public override void UnlockResearch()
    {
        /*
        //Atualiza a variável do Game Manager que o jogador completou a pesquisa.
        GameManager.instance.researchAdventuresGuild = true;
        //Subtrai o valor da pesquisa do cálcio do jogador.
        GameManager.instance.AtualizaCalcio(- cost);
        */
    }
}
