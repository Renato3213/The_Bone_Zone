using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Personagem
{
    Principal,
    Secundário
}

[System.Serializable]
public struct Dialogo
{
    [Header("Texto")]
    [TextArea]
    [Tooltip("caso queira ajustar o tamanho da fonte, escreva assim: 'eu quero <size=150%>ESTA palavra bem grande e <size=50%>ESTA bem pequena'." +
        "\ncaso você queira adicionar negrito, escreva: 'eu quero <b>ESTA</b> palavra em negrito', dentro da caixa de texto no inspetor. não esqueça de fechar com '</b>'")]
    public string text;

    [Header("Personagem")]
    [Tooltip("esse é o personagem que está falando agora")]
    public Sprite sprite;
    [Tooltip("isso determina se ele é principal ou secundario, ou seja, se vai aparecer à direita ou à esquerda da tela")]
    public Personagem personagem;

    [Header("Adicional")]
    [Tooltip("escreva um trigger aqui, e eu notificarei para todos os observadores, caso você queira ativar um evento, ou mudar a cena nesse dialogo, sei lá kk")]
    public string trigger;

}

[CreateAssetMenu(fileName = "Diálogo", menuName = "Diálogos/Criar Novo Diálogo")]
public class DialogoSO : ScriptableObject  
{
    public Dialogo dialogo;
    
}
