using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class PrimeiraCena : MonoBehaviour
{

    [SerializeField]
    DialogoSO[] dialogos;
    int dialogueIndex = 0;
    [SerializeField]
    GameObject areaDialogo;


    [Header("Personagens")]
    public Image Principal;
    public Image Secundario;

    public Animator personagensAnimator;

    [Header("Caixas de dialogo")]
    public GameObject objPrincipal;
    public GameObject objSecundario;
    public TextMeshProUGUI textPrincipal;
    public TextMeshProUGUI textSecundario;

    [SerializeField]
    TextMeshProUGUI dialogue;
    Image dialogueImage;

    void Start()
    {
        //Verso inicial do texto da primeira cena.
        dialogue.text = "TIMOTY GREYCASTLE ..." ;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (dialogueIndex >= dialogos.Length)
            {
                Debug.Log("cabo os texto");
                areaDialogo.SetActive(false);
                return;
            }
            AlteraTexto(dialogos[dialogueIndex]);
            dialogueIndex++ ;
        }
    }


    void AlteraTexto(DialogoSO dialogoSO)
    {


        MudarPersonagem(dialogoSO.dialogo.personagem);

        dialogue.text = dialogoSO.dialogo.text;
        dialogueImage.sprite = dialogoSO.dialogo.sprite;
        #region textos antigos
        //eu comentei isso pra que você possa copiar logo daqui, e poupar um pouco de tempo de escrita.

        //switch(idText)
        //{
        //    case 1:
        //        noDialogo.sprite = Timoty;
        //        dialogo.text = "Finalmente!Acho que adquiri conhecimento o suficiente, já posso sair dessa sala infernal.";
        //        break;
        //    case 2:
        //        dialogo.text = "Igor! Venha aqui, agora! Tenho ótimas notícias!";
        //        break;
        //    case 3:
        //        dialogo.text = "Quanto tempo será que eu passei aqui? Uns 10 anos? Caramba, perdi completamente a noção do tempo...";
        //        break;
        //    case 4:
        //        noDialogo.sprite = Igor;
        //        dialogo.text = "Igor aqui ''sinhô'', oque senhor querer de Igor? Igor promovido? Igor não ter mais que lavar latrina fedorenta de chefe?";
        //        break;
        //    case 5:
        //        noDialogo.sprite = Timoty;
        //        dialogo.text = "Argh! Claro que não! Você ainda me deve dois milênios de serviços! E mais respeito rapazinho, lembre-se de quem um dia teve que gastar 20 preciosos minutos te invocando.";
        //        break;
        //    case 6:
        //        noDialogo.sprite = Igor;
        //        dialogo.text = "Desgrupa chefinho, Igor amar demais da conta ser servinho. Igor gostar demais de limpar latrina fedorenta de chefinho.";
        //        break;
        //    case 7:
        //        dialogo.text = "Mas Igor curioso sinhô, que noticia boa Igor tem que ouvi?";
        //        break;
        //    case 8:
        //        noDialogo.sprite = Timoty;
        //        dialogo.text = "Não me chame de chefinho! Nós já combinamos isso antes!";
        //        break;
        //    case 9:
        //        noDialogo.sprite = Igor;
        //        dialogo.text = "Desgrupa, grande rei dos magos, argoz dos fraco, sinhô dos morto vivo e do submundo.";
        //        break;
        //    case 10:
        //        noDialogo.sprite = Timoty;
        //        dialogo.text = "Assim é melhor! Bem, a noticia boa é que finalmente terminei meus estudos, poderemos sair dessa biblioteca encantada e enfim voltar para o reino, para assim eu mostrar ao papai...";
        //        break;
        //    case 11:
        //        dialogo.text = "Ao Rei, o quão poderoso e sábio eu fiquei, e assim logicamente serei o herdeiro escolhido para assumir o trono!";
        //        break;
        //    case 12:
        //        noDialogo.sprite = Igor;
        //        dialogo.text = "Iupiii! Igor num vai mais precisá comer cabeça de rato todo dia, vai pudê volta a comer casca de fruta!";
        //        break;
        //    case 13:
        //        noDialogo.sprite = Timoty;
        //        dialogo.text = "Exatamente garotão, você poderá comer quantas cascas de fruta quiser! Não só isso, todo o lixo do castelo será seu!";
        //        break;
        //    case 14:
        //        dialogo.text = "Agora vamos, Igor. Está na hora de mostrarmos à todos o quão poderosos e maneiros nós estamos.";
        //        break;
        //    case 15:
        //        //Caixa de diálogo sai.
        //        break;
        //    case 16:
        //        //Caixa de diálogo aparece.
        //        break;
        //    case 17:
        //        dialogo.text = "Ahhh... Ar fresco... Quanto tempo não sentia a doçura de uma leve brisa.";
        //        break;
        //    case 18:
        //        dialogo.text = "Mas ué, onde estão meus homens? Eu dei a ordem de ficarem por aqui enquanto eu terminava meus estudos!";
        //        break;
        //    case 19:
        //        noDialogo.sprite = Igor;
        //        dialogo.text = "Mas, grande rei dos magos, argoz dos fraco, sinhô dos morto vivo e do submundo, se passaro 500 ano desde quando o grande rei dos magos, argoz dos fraco, sinhô dos morto vivo e do submundo entro pra sala magica secreta pra estuda.";
        //        break;
        //    case 20:
        //        noDialogo.sprite = Timoty;
        //        dialogo.text = "QUINHENTOS ANOS???!!!";
        //        break;
        //    case 21:
        //        noDialogo.sprite = Igor;
        //        dialogo.text = "Sim, grande rei dos magos, argoz dos fraco, sinhô dos morto vivo e do submundo, Igor contô tudinho.";
        //        break;
        //    case 22:
        //        noDialogo.sprite = Timoty;
        //        dialogo.text = "Igor... Por gentileza, SÓ ME CHAME DE SENHOR!";
        //        break;
        //    case 23:
        //        noDialogo.sprite = Igor;
        //        dialogo.text = "Tabao senhor.";
        //        break;
        //    case 24:
        //        noDialogo.sprite = Timoty;
        //        dialogo.text = "Mas era suposto de o tempo do lado de fora ficar parado enquanto dentro da sala corria...";
        //        //Som,
        //        break;
        //    case 25:
        //        dialogo.text = "Se bem que mesmo como um lich, eu não envelheci nem um dia, minha pele sequer se decompôs...";
        //        break;
        //    case 26:
        //        dialogo.text = "AQUELA BRUXA VELHA, ME ENGANOU! O tempo, pelo jeito, só parava DENTRO da sala, não FORA!";
        //        break;
        //    case 27:
        //        dialogo.text = "Mas eu tenho uma ideia... Ainda vou fazer meu pai observar minha glória e me conceder direito ao trono.";
        //        break;
        //    case 28:
        //        //Fim de cena.
        //        break;


        //}
        #endregion

    }

    void MudarPersonagem(Personagem personagem)
    {
        if (personagem == Personagem.Principal)
        {
            personagensAnimator.Play("Principal");
            dialogue = textPrincipal;
            dialogueImage = Principal;
            objPrincipal.SetActive(true);
            objSecundario.SetActive(false);
        }

        else if(personagem == Personagem.Secundário)
        {
            personagensAnimator.Play("Secundario");
            dialogue = textSecundario;
            dialogueImage = Secundario;
            objPrincipal.SetActive(false);
            objSecundario.SetActive(true);
        }
    }
}
