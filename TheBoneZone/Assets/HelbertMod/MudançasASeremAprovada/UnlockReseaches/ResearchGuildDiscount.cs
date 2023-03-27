using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchGuildDiscount : TechTree
{
    //Inicializa os atributos da pesquisa.
    public ResearchGuildDiscount()
    {
        //Custo da pesquisa.
        cost = 1000;
        //Texto da descrição: Aventureiros se recuperam mais rápido, mas geram menos ouro nos pubs.
        description.text = "Adventurers Recover Faster but generate less Gold on Pubs.";
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
