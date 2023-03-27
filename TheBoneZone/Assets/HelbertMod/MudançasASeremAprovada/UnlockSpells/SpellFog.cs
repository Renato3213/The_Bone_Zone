using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellFog : SpellsTree
{
    //Inicializa os atributos da magia.
    public SpellFog()
    {
        //Nível da magia.
        level = 2;
        //Custo da magia.
        cost = 1000;
        //Texto da descrição: Reduz o número do dado de ataque inimigo em 1.
        description.text = "Reduces enemy attack die number by 1.";
    }

    public override void UnlockSpell()
    {

    }
}
