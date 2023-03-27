using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTheBone : ISpell
{
    //Referência os atributos do combate que ele está.
    Combat combat;
    //Número tirado  nos dados.
    int[] numberTakenDice; 
    //Índice para controle da inserção dos números tirados nos dados.
    int index = 0;
    //Número mais baixo.
    int lowerNumber = 7;
    //Posição no vetor do menor número.
    int lowestNumberPosition;

    public ReadTheBone(Combat cb)
    {
        combat = cb;
        numberTakenDice = new int [combat.amountPlayerDice];
    }
    
    public void UseSpell()
    {
        //Adiciona o número tirado naquele turno ao vetor.
        numberTakenDice[index] = combat.playerDiceNumber;
        //Aumenta o índice para que os próximos números sejam adicionados.
        index++;
    }
    
    void RerollDicePosition()
    {
        //Percorre o vetor para encontrar o menor número tirado nos dados, caso haja mais de um com o mesmo número prevalece o primeiro encontrado.
        for( int i = 0; i < numberTakenDice.Length; i++)
        {
            //Verifica o número da posição atual com o menor número.
            if(numberTakenDice[i] < lowerNumber)
            {
                //Atribui o número da atual posição para a variável do menor número em caso positivo.
                lowerNumber = numberTakenDice[i];
                //Guarda a posição no vetor do menor número.
                lowestNumberPosition = i;
            }
        }
    }
    
    void Reroll()
    {
        //Sorteia novamente o número do dado com menor número.
        numberTakenDice[lowestNumberPosition] = Random.Range(1,7);
    }
}

