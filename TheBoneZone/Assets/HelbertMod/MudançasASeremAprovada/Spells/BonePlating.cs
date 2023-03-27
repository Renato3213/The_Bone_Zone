using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePlating : ISpell
{
    //Referência os atributos do combate que ele está.
    Combat combat;
    //Quantidade de dados extras de defesa.
    int amountExtrasDice;

    public BonePlating(Combat cb)
    {
        combat = cb;
    }
    
    public void UseSpell()
    {
        //Calcula a quantidade de dados extras baseado na quantidade de esqueletos direcionados.
        amountExtrasDice = combat.amountPlayerSkeletons / 3;
    }
}
