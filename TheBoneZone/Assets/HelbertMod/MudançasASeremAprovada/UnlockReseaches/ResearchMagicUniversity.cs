using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchMagicUniversity : TechTree
{
    //Inicializa os atributos da pesquisa.
    public ResearchMagicUniversity()
    {
        //Custo da pesquisa.
        cost = 1000;
        //Texto da descrição: Desbloqueia feitiços de nível 2.
        description.text = "Unlock Lvl 2 spells.";
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
