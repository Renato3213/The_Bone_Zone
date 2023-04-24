using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    //Referência da magia do jogador.
    public ISpell selectedSpell;
    //Turno de ataque.
    [SerializeField] bool attackTurn = false;
    //Variável de controle da quantidade de dados por esqueletos.
    const int skeletonGroup = 5;
    //Indidacador de qual rodada do turno está.
    int round;
    //Quantidade máxima rodadas por turno.
    int maxRounds;

    [Header("Player Variables")]
    //Quantidade de dados do jogador.
    public int amountPlayerDice;
    //Número do dado do jogador.
    public int playerDiceNumber;
    //Quantidade de esqueletos do jogador.
    public int amountPlayerSkeletons;
    //Lita de dados do jogador.
    public List<int> playerDice = new List<int>();
    //Número de lados do dado do jogador.
    const int sideDicePlayer = 7;

    [Header("NPC Variables")]
    //Quantidade de dados da máquina.
    public int amountNpcDice;
    //Número do dado da máquina
    public int npcDiceNumber;
    //Quantidade de esqueletos da máquina.
    public int amountNpcSkeletons;
    //Lista de dados do npc
    public List<int> opponentDice = new List<int>();
    //Número de lados do dado do jogador.
    public int sideDiceNpc = 7;

    //Informa a Magia selecionada.
    //void SetSpell()
    //{
        //Indica a magia selecionada.
        //this.selectedSpell = GameManager.instance.spell;
    //}

    public void StartCombat(int targetedSkeletons)
    {
        //SetSpell();
        //Atribui a quantidade de esqueletos do jogador.
        amountPlayerSkeletons = targetedSkeletons;
        //Calcula e indica a quantidade de dados do jogador.
        amountPlayerDice = targetedSkeletons / skeletonGroup;
        //Calcula e indica a quantidade de dados da máquina.
        amountNpcDice = amountNpcSkeletons / skeletonGroup;

        //Define a quantidade de lados do dado da máquina.
        switch(selectedSpell)
        {
            case Fog:
                sideDiceNpc = 6;
                break;
            default:
                sideDiceNpc = 7;
                break;
        }

        //Verifica se jogador e máquina tem dados disponíveis.
        if(GetDice())
        {
            //Chama o método que inicia o combate.
            NewTurn();
        }
    }

    //Adiciona 1 dado ao jogador, sendo "i" a quantidade de lados do dado.
    void AddDicePlayer(int i)
    {
        playerDice.Add(i);
    }

    //Adiciona 1 dado ao npc, sendo "i" a quantidade de lados do dado.
    void AddDiceOpponent(int i)
    {
        opponentDice.Add(i);
    }

    //Remove o dado da primeira posição do jogador.
    void RemoveDicePlayer()
    {
        Debug.Log("Remove dado Player");
        playerDice.RemoveAt(0);
    }

    //Remove o dado da primeira posição do npc.
    void RemoveDiceOpponent()
    {
        Debug.Log("Remove dado Adversario");
        opponentDice.RemoveAt(0);
    }
    
    //Método que faz a verificação se ambos tem dados.
    bool GetDice()
    {
        return(amountNpcDice > 0 && amountPlayerDice > 0);
    }

    //Método responsável por chama a mudança de turno e o sorteio dos números nos dados.
    void NewTurn()
    {
        //Remove todos os dados antes de cada turno.
        playerDice.Clear();
        opponentDice.Clear();

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
        //Atribui à ambas listas a quantidade de dados de cada uma.
        for(int i = 0; i < amountPlayerDice; i++)
        {
            AddDicePlayer(sideDicePlayer);
        }
        for(int i = 0; i < amountNpcDice; i++)
        {
            AddDiceOpponent(sideDiceNpc);
        }

        //Define o número máximo de rodadas do turno baseado de acordo com quem tem a maior quantidade de dados.
        maxRounds = (playerDice.Count > opponentDice.Count)? playerDice.Count:opponentDice.Count;
        //Redefine a rodada para 0;
        round = 0;

        //Condicional responsável por comparar os resultados do sorteio dos dados e remover o dado do derrotado na rodada.
        while(round < maxRounds && opponentDice.Count > 0 && playerDice.Count > 0)
        {
            Debug.Log("max: " + maxRounds + "(" + round + ")");
            
            //Sorteio do número do dado do jogador.(Número Aleátorio(0, ValorMáximoDoDado[PosiçãoDoDado = NúmeroDaRodada % QuantidadeDeDadosDoJogador]))
            playerDiceNumber = Random.Range(1, playerDice[round % playerDice.Count]);
            //Sorteio do número do dado da máquina.(Número Aleátorio(0, ValorMáximoDoDado[PosiçãoDoDado = NúmeroDaRodada % QuantidadeDeDadosDaMáquina]))
            npcDiceNumber = Random.Range(1, opponentDice[round % opponentDice.Count]);
            Debug.Log("Jogador: " + playerDiceNumber + "  |   Adversario: " + npcDiceNumber);

            //Compara se deu empate nos dados.
            if(playerDiceNumber == npcDiceNumber)
            {
                Debug.Log("Empate");
                //Se dá empate na rodada e for turno de ataque remove o dado do jogador, caso seja o turno de defesa remove o dado da máquina.
                if(attackTurn)
                {
                    RemoveDicePlayer();
                }
                else
                {
                    RemoveDiceOpponent();
                }
            }
            //Se o número do dado do jogador for maior remove um dado da máquina.
            else if(playerDiceNumber > npcDiceNumber)
            {
                Debug.Log("Player ganha");
                RemoveDiceOpponent();
            }
            //Se o número do dado da máquina for maior remove um dado do jogador.
            else
            {
                Debug.Log("Adversário ganha");
                RemoveDicePlayer();
            }
            round++;
        }

        //Chama o método que compara os resultados dos dados.
        CompareDice();
    }
    
    //Método que verifica quem foi o vencedor ao final do turno.
    void CompareDice()
    {
        //Compara se deu empate no turno.
        if(playerDiceNumber == npcDiceNumber)
        {
            //Se dá empate e seja o turno de ataque remove o dado do jogador, caso seja o turno de defesa remove o dado da máquina.
            if(attackTurn)
            {
                amountPlayerDice -= 1;
            }
            else
            {
                amountNpcDice -= 1;
            }
        }
        //Remove o dado do jogador caso seja o perdedor do turno.
        else if(opponentDice.Count > playerDice.Count)
        {
            amountPlayerDice -= 1;
        }
        //Remove o dado da máquina caso seja o perdedor do turno.
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
        if(GetDice())
        {
            //Inicia um novo turno caso jogador e máquina tenham dados disponíveis.
            NewTurn();
        }
    }
}
