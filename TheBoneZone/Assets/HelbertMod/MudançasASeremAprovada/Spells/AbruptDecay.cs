using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbruptDecay : ISpell
{
    //Referência os atributos do combate que ele está.
    Combat combat;

    public AbruptDecay(Combat cb)
    {
        combat = cb;
    }

    public void UseSpell()
    {
        //Remove 1 dado da máquina.
        combat.amountNpcDice -= 1;
    }
}
