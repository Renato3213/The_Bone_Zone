using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBoneTransmutation : SpellsTree
{
    //Inicializa os atributos da magia.
    public SpellBoneTransmutation()
    {
        //Nível da magia.
        level = 2;
        //Custo da magia.
        cost = 1000;
        //Texto da descrição: Ganhe ouro extra ao custo de 30% do cálcio.
        description.text = "Gain extra gold at the cost of 30% of the calcium.";
    }

    public override void UnlockSpell()
    {

    }
}
