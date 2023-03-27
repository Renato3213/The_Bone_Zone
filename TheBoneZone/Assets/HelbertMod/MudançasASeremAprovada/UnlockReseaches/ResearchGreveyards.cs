using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchGreveyards : TechTree
{
    //Inicializa os atributos da pesquisa.
    public ResearchGreveyards()
    {
        //Custo da pesquisa.
        cost = 1000;
        //Texto da descrição: Casas Melhores. Ocupa mais espaço. Gera mais felicidade.
        description.text = "Better Houses. Occupy more space. Generate more happiness.";
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
