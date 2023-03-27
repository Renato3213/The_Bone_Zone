using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchAdventuresGuild : TechTree
{
    //Inicializa os atributos da pesquisa.
    public ResearchAdventuresGuild()
    {
        //Custo da pesquisa.
        cost = 1000;
        //Texto da descrição: Desbloqueia o Esqueleto Aventureiro.
        description.text = "Unlock the Adventurer Skeleton.";
    }

    public override void UnlockResearch()
    {
        /*
        if(GameManager.instance.Calcio >= cost)
        {
            //Atualiza a variável do Game Manager que o jogador completou a pesquisa.
            GameManager.instance.researchAdventuresGuild = true;
            //Subtrai o valor da pesquisa do cálcio do jogador.
            GameManager.instance.AtualizaCalcio(- cost);
        }
        */
        
    }
}
