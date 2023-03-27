using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchAdvancedNecromancy : TechTree
{
    //Inicializa os atributos da pesquisa.
    public ResearchAdvancedNecromancy()
    {
        //Custo da pesquisa.
        cost = 1000;
        //Texto da descrição: Dois esqueletos pelo preço de um.
        description.text = "Two skeletons for the price of one.";
    }

    public override void UnlockResearch()
    {
        /*
        if(GameManager.instance.Calcio >= cost)
        {
            //Atualiza a variável do Game Manager que o jogador completou a pesquisa.
            GameManager.instance.researchAdvancedNecromancy = true;
            //Subtrai o valor da pesquisa do cálcio do jogador.
            GameManager.instance.AtualizaCalcio(- cost);
        }
        */
    }
}
