using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneCarving : ISpell
{
    //Referência os atributos do combate que ele está.
    Combat combat;

    public BoneCarving(Combat cb)
    {
        combat = cb;
    }
    
    public void UseSpell()
    {
        
    }
}
