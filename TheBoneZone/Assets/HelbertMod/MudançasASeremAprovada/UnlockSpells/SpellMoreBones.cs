using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellMoreBones : SpellsTree
{
    //Inicializa os atributos da magia.
    public SpellMoreBones()
    {
        //Nível da magia.
        level = 1;
        //Custo da magia.
        cost = 1000;
        //Texto da descrição: Ganhe mais cálcio se vencer a batalha.
        description.text = "Gain more calcium if you win the battle.";
    }

    public override void UnlockSpell()
    {

    }
}
