using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Esqueletos : MonoBehaviour
{
    public enum Especialidades{Geral, Farmer, Knight, Scout};
    public enum Construcoes{SemAtividade, EmMissoes, Casa, Fazenda, Biblioteca, Dojo, Bar, /*TorreFlechas, TorreCanhao, Regimento, BoneHydra*/};
    public enum Estamina{Nivel1, Nivel2, Nivel3};
    public Especialidades trabalho;
    public Construcoes local;
    public Estamina cansaco;
    public bool emTrabalho = false;
    public int felicidade = 100; 
    /*public int vida;
    public int agilidade;*/
    public float estaminaAtual = 10;
    public float totalEstamina = 10;
    public float tempoEstamina;
    public float tempoFelicidade;
    public float eficienciaTrabalho;
    public Renderer rend;
    public Transform destino;
    public Vector3 destinatario;
    public NavMeshAgent agente;
    public GameObject atualLocal;
    public GameObject ultimoLocal;

    void Start()
    {
        ControlaListas.instance.listaEsqueletos.Add(this.gameObject);
        GameManager.instance.totalInfamia += .1f;
        agente = GetComponent<NavMeshAgent>();
        //Evita erros no começo da execução.(OBS: Se colocar ".position" para, e não sei o motivo.)
        destino = transform;
        destinatario = agente.destination;
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        //Adiciona e remove o esqueleto da lista de trabalho.
        if(emTrabalho == true)
        {
            if(ControlaListas.instance.listaTrabalhando.Contains(this.gameObject) == false)
            {
                ControlaListas.instance.listaTrabalhando.Add(this.gameObject);
            }
        }
        else
        {
            if(ControlaListas.instance.listaTrabalhando.Contains(this.gameObject) == true)
            {
                ControlaListas.instance.listaTrabalhando.Remove(this.gameObject);
                atualLocal.GetComponent<Fazendas>().quantidadeEsqueletos -= 1;
                atualLocal = null;
            }
        }

        //Atualização o destino do esqueleto.
        if(Vector3.Distance(destinatario, destino.position) > 1.0f)
        {
            destinatario = destino.position;
            agente.destination = destinatario;
        }

        //Ativa e desativa a renderização do esqueleto ao estar na construção.
        if(local != Construcoes.SemAtividade && Vector3.Distance(transform.position, destino.position) < 3.5f)
        {
            rend.enabled = false;
        }
        else
        {
            rend.enabled = true;
        }

        //Níveis de estamina do esqueleto.
        switch (cansaco)
        {
            case Estamina.Nivel1:
                totalEstamina = 10;
                break;
            case Estamina.Nivel2:
                totalEstamina = 30;
                break;
            case Estamina.Nivel3:
                totalEstamina = 50;
                break;
        }
       
        //Dispensa o esqueleto do trabalho ao estar completamente cansado.
        if(estaminaAtual < 0)
        {
            estaminaAtual = 0;
            local = Construcoes.SemAtividade;
        }

        //Dispensa o esqueleto do trabalho ao estar infeliz.
        if(felicidade <= 0)
        {
            felicidade = 0;
            local = Construcoes.SemAtividade;
            /*foreach(GameObject bar in ControlaListas.instance.listaBares)
            {
                if(bar.GetComponent<Bares>().quantidadeEsqueletos < bar.GetComponent<Bares>().limiteEsqueletos)
                {   
                    ultimoLocal = atualLocal;
                    ultimoLocal.GetComponent<Fazendas>().quantidadeEsqueletos -= 1;
                    destino = bar.GetComponent<Bares>().transform;
                    local = Construcoes.Bar;
                    atualLocal = bar.GetComponent<Bares>().gameObject;
                    bar.GetComponent<Bares>().quantidadeEsqueletos += 1;
                    break;
                }
            }*/
        }

        //Limita a estamina.
        if(estaminaAtual >= totalEstamina)
        {
            estaminaAtual = totalEstamina;
        }

        //Limita a felicidade.
        if(felicidade >= 100)
        {
            felicidade = 100;
            if(atualLocal != null && local == Construcoes.Bar)
            {
                atualLocal.GetComponent<Bares>().quantidadeEsqueletos -= 1;
                atualLocal = null;
            }
        }

        //Lógica para perda e ganho de felicidade.
        tempoFelicidade += Time.deltaTime;
        if(emTrabalho == true)
        {
            if(tempoFelicidade > 1f)
            {
                felicidade -= 2;
                tempoFelicidade = 0;
            }
        }

        //Lógica para relação de perda e de ganho de estamina de acordo com a localização atual.
        switch (local)
        {
            case Construcoes.SemAtividade:
                emTrabalho = false;
                break;
            case Construcoes.Casa:
                emTrabalho = false;
                if(estaminaAtual != totalEstamina)
                {
                    tempoEstamina += Time.deltaTime;
                    if(tempoEstamina > 1f)
                    {
                        estaminaAtual += 2f;
                        tempoEstamina = 0;
                    }
                }
                break;
            case Construcoes.Fazenda:
                emTrabalho = true;
                tempoEstamina += Time.deltaTime;
                if(tempoEstamina > 1f)
                {
                    estaminaAtual -= 0.25f;
                    tempoEstamina = 0;
                }
                break;
            case Construcoes.Biblioteca:
                emTrabalho = true;
                tempoEstamina += Time.deltaTime;
                if(tempoEstamina > 1f)
                {
                    estaminaAtual -= 0.5f;
                    tempoEstamina = 0;
                }
                break;
            case Construcoes.Dojo:
                emTrabalho = true;
                tempoEstamina += Time.deltaTime;
                if(tempoEstamina > 1f)
                {
                    estaminaAtual -= 1f;
                    tempoEstamina = 0;
                }
                break;
            case Construcoes.Bar:
                emTrabalho = false;
                if(estaminaAtual != totalEstamina)
                {
                    tempoEstamina += Time.deltaTime;
                    if(tempoFelicidade > 1f)
                    {
                        felicidade += 3;
                        tempoFelicidade = 0;
                    }
                }
                break;
        }

        //Lógica para a eficiência do esqueleto.
        if (felicidade <= 25)
        {
            eficienciaTrabalho = 0.5f;
        }
        else if (felicidade >= 26 && felicidade <= 50)
        {
            eficienciaTrabalho = 0.67f;
        }
        else if (felicidade >= 51 && felicidade <= 75)
        {
            eficienciaTrabalho = 1f;
        }
        else if (felicidade >= 76 && felicidade <= 90)
        {
            eficienciaTrabalho = 1.5f;
        }
        else if (felicidade >= 91 && felicidade <= 100)
        {
            eficienciaTrabalho = 2f;
        }
    }
}
