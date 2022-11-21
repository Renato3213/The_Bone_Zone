using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

/*public class BotaoTrabalho : MonoBehaviour
{
    //public GameObject esqueletinho;
    public Slider solicitado;
    public float min = 1f;

    // Start is called before the first frame update
    void Start()
    {
        solicitado.minValue = min;
    }

    // Update is called once per frame
    void Update()
    {
        solicitado.maxValue = this.gameObject.GetComponent<Fazendas>().limiteEsqueletos - this.gameObject.GetComponent<Fazendas>().quantidadeEsqueletos;
    }

    public void Botao()
    {
        if(this.gameObject.GetComponent<Fazendas>().quantidadeEsqueletos < this.gameObject.GetComponent<Fazendas>().limiteEsqueletos)
        {
            Designacao((int)solicitado.value);
        }
    }

    public void Designacao(int qntdSolicitada)
    {
        int designados = 0;

        foreach(GameObject esqueleto in ControlaListas.instance.listaEsqueletos)
        {
            if(designados == qntdSolicitada || this.gameObject.GetComponent<Fazendas>().quantidadeEsqueletos == this.gameObject.GetComponent<Fazendas>().limiteEsqueletos)
            {
                break;
            }
            if(esqueleto.GetComponent<Esqueletos>().emTrabalho == false)
            {   
                esqueleto.GetComponent<Esqueletos>().local = Esqueletos.Construcoes.Fazenda;
                esqueleto.GetComponent<Esqueletos>().destino = transform;
                esqueleto.GetComponent<Esqueletos>().atualLocal = this.gameObject;
                this.gameObject.GetComponent<Fazendas>().quantidadeEsqueletos += 1;
                designados += 1;
            }
        }
    }
}*/
