using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchCrypts : TechTree
{
    //Inicializa os atributos da pesquisa.
    public ResearchCrypts()
    {
        //Custo da pesquisa.
        cost = 1000;
        //Texto da descrição: Desbloquea casas.
        description.text = "Unlock houses.";
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
