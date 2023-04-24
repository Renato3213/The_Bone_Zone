using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuintaCena : MonoBehaviour
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
        //Aparece a caixa de diálogo da quinta cena.
        //Fade in do Timoty
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && emDialogo && idText < 14)
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
                dialogo.text = "Que estranho, parece que o ritmo dos esqueletos diminuiu muito. O que será que aconteceu?";
                break;
            case 2:
                dialogo.text = "Será que os ossos estão se desgastando mais rapidamente por conta do trabalho árduo? Ou será que é só...";
                break;
            case 3:
                noDialogo.sprite = null;
                dialogo.text = "''Um esqueleto se aproxima de Timoty''";
                break;
            case 4:
                noDialogo.sprite = Esqueleto;
                dialogo.text = "Sinhô, nós cansado, nós querer beber.";
                break;
            case 5:
                noDialogo.sprite = Timoty;
                dialogo.text = "Mas vocês sequer tem que comer, porque querem tanto beber água?";
                break;
            case 6:
                noDialogo.sprite = Esqueleto;
                dialogo.text = "Nós não querer água, nós querer cerveja!";
                break;
            case 7:
                noDialogo.sprite = Timoty;
                dialogo.text = "Agora eu entendo! Isso são ecos de suas vidas passadas! Vocês tentam reproduzir comportamentos que o seu eu vívido tinha, mesmo depois da morte!";
                break;
            case 8:
                dialogo.text = "Como eu pude me esquecer de algo tão importante! Pagina 423, linha 36 do Necronômicon de Azdalin, ''Todo corpo tende a...";
                break;
            case 9:
                noDialogo.sprite = Esqueleto;
                dialogo.text = "Nós querer cerveja!";
                break;
            case 10:
                noDialogo.sprite = Timoty;
                dialogo.text = "Se eu der bebidas alcóolicas para vocês, o trabalho vai ser mais eficiente?";
                break;
            case 11:
                noDialogo.sprite = Esqueleto;
                dialogo.text = "Sim.";
                break;
            case 12:
                noDialogo.sprite = Timoty;
                dialogo.text = "Argh, fazer o que né...";
                break;
            case 13:
                dialogo.text = "Igor! Invada a taverna mais próxima e roube o máximo de bebidas alcoólicas que conseguir! Vamos abrir um pub!";
                break;
            case 14:
                //Fim de cena.
                break;
        }
    }
}
