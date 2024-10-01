using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Card", fileName = "New Card")]
public class SOCard : ScriptableObject
{
    public enum CardType
    {
        Number,
        Skip,
        Invert,
        Plus2,
        Plus4,
        ChangeColor
    }

    public CardType type;
    public int digit;
    public Sprite sprite;


    
}
