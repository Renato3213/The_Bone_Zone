using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellNec_romantic : SpellsTree
{
    //Inicializa os atributos da magia.
    public SpellNec_romantic()
    {
        //Nível da magia.
        level = 2;
        //Custo da magia.
        cost = 1000;
        //Texto da descrição: Perca 20% do cálcio que ganharia, mas crie 1 esqueleto a cada 10 cálcio.
        description.text = "Lose 20% of the calcium you would win but create 1 skeleton every 10 calcium.";
    }

    public override void UnlockSpell()
    {

    }
}
