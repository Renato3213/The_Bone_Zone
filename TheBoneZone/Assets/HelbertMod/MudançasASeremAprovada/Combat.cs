using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public ISpell selectedSpell;
    //Turno de ataque.
    [SerializeField] bool attackTurn = false;

    [Header("Player Variables")]
    //Quantidade de dados do jogador.
    public int amountPlayerDice;
    //Número do dado do jogador.
    public int playerDiceNumber;
    //Quantidade de esqueletos do jogador.
    public int amountPlayerSkeletons;

    [Header("NPC Variables")]
    //Quantidade de dados da máquina.
    public int amountNpcDice;
    //Número do dado da máquina
    public int npcDiceNumber;
    //Quantidade de esqueletos da máquina.
    public int amountNpcSkeletons;
    
    public void StartCombat(int targetedSkeletons)
    {
        //Atribui a quantidade de esqueletos do jogador
        amountPlayerSkeletons = targetedSkeletons;
        //Calcula e indica a quantidade de dados do jogador;
        amountPlayerDice = targetedSkeletons / 5;
        //Atribui a mesma quantidade de dados do jogador para a máquina.
        amountNpcDice = amountPlayerDice;
        //Verifica se jogador e máquina tem dados disponíveis.
        if(GetDice() == true)
        {
            //Chama o método que inicia o combate.
            NewTurn();
        }
    }
    
    //Método que faz a verificação se ambos tem dados.
    bool GetDice()
    {
        if(amountNpcDice != 0 && amountPlayerDice != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Método responsável por chama a mudança de turno e o sorteio dos números nos dados.
    void NewTurn()
    {
        //Chama o método que alterna entre o turno de ataque e defesa.
        ChangeTurn();
        //Chama o método que faz o sorteio dos números dos dados.
        DiceDraw();
    }

    //Método que controla e troca os turnos do combate.
    void ChangeTurn()
    {
        //Muda entre turno de ataque e defesa.
        attackTurn = !attackTurn;
    }
    
    //Método que sorteia os números dos dados.
    void DiceDraw()
    {
        //Sorteia o dado do jogador.
        playerDiceNumber = Random.Range(1, 7);
        //Sorteia o dado da máquina.
        npcDiceNumber = Random.Range(1, 7);
        //Chama o método que compara os resultados dos dados.
        CompareDice();
    }
    
    //Método responsável por comparar os resultados do sorteio dos dados e remover o dado do derrotado no turno.
    void CompareDice()
    {
        //Compara se deu empate nos dados.
        if(npcDiceNumber == playerDiceNumber)
        {
            //Se dá empate no turno de ataque remove o dado do jogador, caso seja o turno de defesa remove o dado da máquina.
            if(attackTurn == true)
            {
                amountPlayerDice -= 1;
            }
            else
            {
                amountNpcDice -= 1;
            }
        }
        //Se o número do dado da máquina for maior remove um dado do jogador.
        else if(npcDiceNumber > playerDiceNumber)
        {
            amountPlayerDice -= 1;
        }
        //Se o número do dado do jogador for maior remove um dado da máquina.
        else
        {
            amountNpcDice -= 1;
        }
        //Chama o método que mostra o resultado do turno.
        ShowResults();
    }

    //Método que é responsável por mostrar os reultados e chamar a verifacação se há mais dados para que se inicie um novo turno caso seja positivo.
    void ShowResults()
    {
        //Animação.
        //AtualizaHUD

        //Verifica se jogador e máquina tem dados disponíveis.
        if(GetDice() == true)
        {
            //Inicia um novo turno caso jogador e máquina tenham dados disponíveis.
            NewTurn();
        }
    }
}
