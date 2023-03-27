using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneTransmutation : ISpell
{
    //Referência os atributos do combate que ele está.
    Combat combat;

    public BoneTransmutation(Combat cb)
    {
        combat = cb;
    }

    public void UseSpell()
    {
        
    }
}
