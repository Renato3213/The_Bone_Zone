using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkblast : ISpell
{
    //Referência os atributos do combate que ele está.
    Combat combat;
    //Dado extra um.
    int diceOne;
    //Dado extra dois.
    int diceTwo;

    public Darkblast(Combat cb)
    {
        combat = cb;
    }

    public void UseSpell()
    {
        //Sorteia os dados extras.
        diceOne = Random.Range(1,7);
        diceTwo = Random.Range(1,7);
    }
}
