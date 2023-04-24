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
