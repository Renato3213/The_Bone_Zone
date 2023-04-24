using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuartaCena : MonoBehaviour
{
    //Referência do texto.
    public TextMeshProUGUI dialogo;
    public Image noDialogo;
    public Sprite Timoty;
    public Sprite Igor;
    public Sprite Esqueleto;
    int idText = 0;
    bool emDialogo = true;

    void Start()
    {
        //Aparece a caixa de diálogo da quarta cena.
        //Fade in do Timoty
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && emDialogo && idText < 18)
        {
            idText += 1;
            AlteraTexto();
        }
    }

    void AlteraTexto()
    {
        switch(idText)
        {
            case 1:
                noDialogo.sprite = Timoty;
                dialogo.text = "Droga!";
                break;
            case 2:
                dialogo.text = "Não sobrou mais nenhum osso, evoquei todo meu exército de volta. Mas apenas isso não é o bastante!";
                break;
            case 3:
                dialogo.text = "Onde eu poderia conseguir mais ossos? Hmmm...";
                break;
            case 4:
                noDialogo.sprite = Igor;
                dialogo.text = "Porque sinhô não planta osso?";
                break;
            case 5:
                noDialogo.sprite = Timoty;
                dialogo.text = "ARGH! Que susto Igor! Desde quando você está aí?";
                break;
            case 6:
                noDialogo.sprite = Igor;
                dialogo.text = "Esse ser superpoder de Igor. Igor poder ficar parado sem fazer barulho e ninguém perceber Igor. Observar Igor.";
                break;
            case 7:
                dialogo.text = "...";
                break;
            case 8:
                noDialogo.sprite = Timoty;
                dialogo.text = "Tudo bem Igor! Eu já entendi! Não temos tempo seu idiota!";
                break;
            case 9:
                dialogo.text = "Conclua sua sugestão imbecil para seguirmos com as demais alternativas. Infelizmente não estou descartando nenhuma sugestão, então estou disposto a ouvir sua ''ideia''.";
                break;
            case 10:
                noDialogo.sprite = Igor;
                dialogo.text = "Bem, se fazendeiro precisar de uva ele plantar uva, se fazendeiro precisar de pepino ele plantar pepino, se plebeu precisar relaxar ele plantar ...";
                break;
            case 11:
                noDialogo.sprite = Timoty;
                dialogo.text = "Pelo amor de deus... Porquê eu ainda dou ouvidos.";
                break;
            case 12:
                dialogo.text = "Mas espere... Podemos realmente fazer campos de escavação para tentar achar ossos perdidos! Acho que isso pode ser uma solução!";
                break;
            case 13:
                dialogo.text = "Já temos até trabalhadores para procurar esses ossos! Perfeito!";
                break;
            case 14:
                noDialogo.sprite = Igor;
                dialogo.text = "Igual Igor falou: fazenda de osso";
                break;
            case 15:
                noDialogo.sprite = Timoty;
                dialogo.text = "Não Igor, sua ideia pífia apenas me gerou uma faísca de inspiração para que eu tivesse minha ideia geni...";
                break;
            case 16:
                noDialogo.sprite = Igor;
                dialogo.text = "Fazenda de osso";
                break;
            case 17:
                noDialogo.sprite = Timoty;
                dialogo.text = "Argh... É Igor, é uma ''fazenda de ossos''...";
                break;
            case 18:
                //Fim de cena.
                break;
        }
    }
}
