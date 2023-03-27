using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchMarkets : TechTree
{
    //Inicializa os atributos da pesquisa.
    public ResearchMarkets()
    {
        //Custo da pesquisa.
        cost = 1000;
        //Texto da descrição: Esqueletos geram ouro passivamente ao custo de produtos agrícolas. Eleva a Felicidade.
        description.text = "Skeletons generate gold passively at the cost of farm products. Raises Happiness.";
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
