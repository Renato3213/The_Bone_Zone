using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchPhDInNecromancy : TechTree
{
    //Inicializa os atributos da pesquisa.
    public ResearchPhDInNecromancy()
    {
        //Custo da pesquisa.
        cost = 1000;
        //Texto da descrição: Desbloqueia feitiços de nível 3.
        description.text = "Unlock Lvl 3 spells.";
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
