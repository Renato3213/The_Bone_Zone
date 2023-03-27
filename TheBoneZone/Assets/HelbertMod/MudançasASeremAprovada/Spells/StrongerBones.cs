using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongerBones : ISpell
{
    //Referência os atributos do combate que ele está.
    Combat combat;
    //Quantidade de dados extras de ataque.
    int amountExtrasDice;

    public StrongerBones(Combat cb)
    {
        combat = cb;
    }

    public void UseSpell()
    {
        //Calcula a quantidade de dados extras baseado na quantidade de esqueletos direcionados.
        amountExtrasDice = combat.amountPlayerSkeletons / 3;
    }
}
