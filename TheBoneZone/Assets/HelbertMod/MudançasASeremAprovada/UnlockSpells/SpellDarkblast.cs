using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellDarkblast : SpellsTree
{
    //Inicializa os atributos da magia.
    public SpellDarkblast()
    {
        //Nível da magia.
        level = 1;
        //Custo da magia.
        cost = 1000;
        //Texto da descrição: Jogue 2 dados extras APÓS o combate.
        description.text = "Roll 2 extra die AFTER combat.";
    }

    public override void UnlockSpell()
    {

    }
}
