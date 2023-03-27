using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellTheBoneZone : SpellsTree
{
    //Inicializa os atributos da magia.
    public SpellTheBoneZone()
    {
        //Nível da magia.
        level = 3;
        //Custo da magia.
        cost = 1000;
        //Texto da descrição: Dobre a quantidade de dados que você rola durante a batalha.
        description.text = "Double the amount of dice you roll during the battle.";
    }

    public override void UnlockSpell()
    {

    }
}
