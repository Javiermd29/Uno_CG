using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Card : MonoBehaviour
{
    private SOCard _soCard;
    private Color _color;

    private bool isFaceDown;

    [SerializeField] private SpriteRenderer cardSpriteRenderer;
    [SerializeField] private SpriteRenderer symbolSpriteRenderer;


    private void SetupCardVisuals(SOCard soCard, Color color)
    {

        _soCard = soCard;
        _color = color;

        if (soCard.type == CardType.Plus4
            || soCard.type == CardType.ChangeColor)
        {
            cardSpriteRenderer.color = Color.black;
        }
        else
        {
            cardSpriteRenderer.color = color;
        }
    }
    
    private void IsFaceDown(bool isFaceDown)
    {
        _isFaceDown = IsFaceDown;
        backCard.SetActive(IsFaceDown);
    }

}
