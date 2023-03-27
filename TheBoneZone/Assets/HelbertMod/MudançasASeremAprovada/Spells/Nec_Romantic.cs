using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nec_Romantic : ISpell
{
    //Referência os atributos do combate que ele está.
    Combat combat;

    public Nec_Romantic(Combat cb)
    {
        combat = cb;
    }

    public void UseSpell()
    {
        
    }
}
