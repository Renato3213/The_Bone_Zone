using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBoneZone : ISpell
{
    //Referência os atributos do combate que ele está.
    Combat combat;

    public TheBoneZone(Combat cb)
    {
        combat = cb;
    }

    public void UseSpell()
    {

    }
}
