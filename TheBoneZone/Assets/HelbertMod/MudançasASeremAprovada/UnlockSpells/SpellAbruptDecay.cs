using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellAbruptDecay : SpellsTree
{
    //Inicializa os atributos da magia.
    public SpellAbruptDecay()
    {
        //Nível da magia.
        level = 3;
        //Custo da magia.
        cost = 1000;
        //Texto da descrição: Remova um dado do inimigo permanentemente.
        description.text = "Remove one die from the enemy permanently.";
    }

    public override void UnlockSpell()
    {

    }
}
