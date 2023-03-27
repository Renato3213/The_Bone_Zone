using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchBetterTools : TechTree
{
    //Inicializa os atributos da pesquisa.
    public ResearchBetterTools()
    {
        //Custo da pesquisa.
        cost = 1000;
        //Texto da descrição: As fazendas produzem mais recursos.
        description.text = "Farms produce more resources.";
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
