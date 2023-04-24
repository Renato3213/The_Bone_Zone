using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SextaCena : MonoBehaviour
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
        //Aparece a caixa de diálogo da sexta cena.
        //Fade in do Timoty
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && emDialogo && idText < 8)
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
                dialogo.text = "Aqui nós damos o primeiro passo para a minha... Digo, a nossa, ascensão! E para começar bem, vamos ensinar uma lição à essa bruxa velha que nos passou a perna!";
                break;
            case 2:
                dialogo.text = "Vamos tomar esse muquifo que ela chama de cidade, e mostrar pra ela do que somos capazes! Caso façamos isso, nossa glória será certa!";
                break;
            case 3:
                noDialogo.sprite = null;
                dialogo.text = "...";
                break;
            case 4:
                noDialogo.sprite = Timoty;
                dialogo.text = "Argh...";
                break;
            case 5:
                dialogo.text = "E vocês poderão ficar com toda cerveja que houver nesse vilarejo!";
                break;
            case 6:
                noDialogo.sprite = Igor;
                dialogo.text = "AAAAAAAAAAAAHHH! Destruir vilarejo!";
                break;
            case 7:
                noDialogo.sprite = Timoty;
                dialogo.text = "Eu mereço...";
                break;
            case 8:
                //Fim de cena.
                break;
        }
    }
}
