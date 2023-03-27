using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreBones : ISpell
{
    //Referência os atributos do combate que ele está.
    Combat combat;

    public MoreBones(Combat cb)
    {
        combat = cb;
    }

    public void UseSpell()
    {
        
    }
}
