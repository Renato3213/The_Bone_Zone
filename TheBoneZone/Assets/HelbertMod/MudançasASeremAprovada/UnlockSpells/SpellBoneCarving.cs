using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBoneCarving : SpellsTree
{
    //Inicializa os atributos da magia.
    public SpellBoneCarving()
    {
        //Nível da magia.
        level = 3;
        //Custo da magia.
        cost = 1000;
        //Texto da descrição: Escolha um dado, ele sempre rolará 4, 5 ou 6.
        description.text = "Pick a dice, he will always roll 4, 5 or 6.";
    }

    public override void UnlockSpell()
    {

    }
}
