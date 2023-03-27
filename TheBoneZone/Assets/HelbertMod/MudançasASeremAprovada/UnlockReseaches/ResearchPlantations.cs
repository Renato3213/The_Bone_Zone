using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchPlantations : TechTree
{
    //Inicializa os atributos da pesquisa.
    public ResearchPlantations()
    {
        //Custo da pesquisa.
        cost = 1000;
        //Texto da descrição: Fazendas maiores.
        description.text = "Bigger farms.";
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
