using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellReadTheBones : SpellsTree
{
    //Inicializa os atributos da magia.
    public SpellReadTheBones()
    {
        //Nível da magia.
        level = 2;
        //Custo da magia.
        cost = 1000;
        //Texto da descrição: Role novamente seu rolo mais baixo.
        description.text = "Reroll your lowest roll.";
    }

    public override void UnlockSpell()
    {

    }
}
