using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : ISpell
{
    //Referência os atributos do combate que ele está.
    Combat combat;

    public Fog(Combat cb)
    {
        combat = cb;
    }

    public void UseSpell()
    {
        //Verifica se o número da máquina sorteado é maior que 1. 
        if(combat.npcDiceNumber != 1)
        {
            //Subtrai 1 do número sorteado.
            combat.npcDiceNumber -= 1;
        }
    }
}
