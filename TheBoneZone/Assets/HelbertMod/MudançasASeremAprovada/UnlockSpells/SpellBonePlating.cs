using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBonePlating : SpellsTree
{
    //Inicializa os atributos da magia.
    public SpellBonePlating()
    {
        //Nível da magia.
        level = 1;
        //Custo da magia.
        cost = 1000;
        //Texto da descrição: Role 1 dado extra na defesa para cada 3 esqueletos.
        description.text = "Roll 1 extra dice on defense for every 3 skeletons.";
    }

    public override void UnlockSpell()
    {

    }
}
