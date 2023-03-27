using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellStrongerBones : SpellsTree
{
    //Inicializa os atributos da magia.
    public SpellStrongerBones()
    {
        //Nível da magia.
        level = 1;
        //Custo da magia.
        cost = 1000;
        //Texto da descrição: Role 1 dado extra no ataque para cada 3 esqueletos.
        description.text = "Roll 1 extra dice on attack for every 3 skeletons.";
    }

    public override void UnlockSpell()
    {

    }
}
