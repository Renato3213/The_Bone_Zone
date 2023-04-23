using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadoController : MonoBehaviour
{
    public List<int> dadoPlayer = new List<int>();
    public List<int> dadoAdversario = new List<int>();
    int round, maxRounds;
    
    public void AddDadoPlayer(int i){
        dadoPlayer.Add(i);
    }

    public void AddDadoAdversario(int i){
        dadoAdversario.Add(i); //i número de lados do dado
    }

    public void RemoveDadoPlayer(){
        Debug.Log("Remove dado Player");
        dadoPlayer.RemoveAt(0);
    }

    public void RemoveDadoAdversario(){
        dadoAdversario.RemoveAt(0);
    }

    public void InicarRoud(){
        maxRounds = (dadoPlayer.Count > dadoAdversario.Count)?dadoPlayer.Count:dadoAdversario.Count;
        round= 0;
    }

    public bool RodaTurno(){
        
        Debug.Log("max: " + maxRounds + "(" + round + ")");
        int player, adv;
        player = Random.Range(0, dadoPlayer[round % dadoPlayer.Count]);
        adv = Random.Range(0, dadoAdversario[round % dadoAdversario.Count]);
        if (player == adv) 
            Debug.Log("Empate");
        else if (player > adv){
            Debug.Log("Player ganha");
            RemoveDadoAdversario();
        } else {
            Debug.Log("Adversário ganha");
            RemoveDadoPlayer();

        }
        round++;
        if (round > maxRounds){
            Debug.Log("Fim do jogo");
            return false;
        }
        return true;
    }

    void Start()
    {
        AddDadoPlayer(5);
        AddDadoPlayer(5);
        AddDadoPlayer(5);
        AddDadoPlayer(5);
        AddDadoAdversario(5);
        AddDadoAdversario(5);
        AddDadoAdversario(5);
        InicarRoud();
        while(RodaTurno()){
            Debug.Log("Roda Turno");
        }

    }
}
