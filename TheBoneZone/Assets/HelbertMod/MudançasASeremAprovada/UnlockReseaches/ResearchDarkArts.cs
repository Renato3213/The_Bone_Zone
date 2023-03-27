using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchDarkArts : TechTree
{
    //Inicializa os atributos da pesquisa.
    public ResearchDarkArts()
    {
        //Custo da pesquisa.
        cost = 1000;
        //Texto da descrição: Revive 30% dos esqueletos perdidos na batalha.
        description.text = "Revive 30% of lost skeletons on Battle.";
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
