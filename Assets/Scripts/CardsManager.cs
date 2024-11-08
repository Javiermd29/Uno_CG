using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardsManager : MonoBehaviour
{
    public static CardsManager Instance;

    [SerializeField] private SOCard[] soCards;
    [SerializeField] private GameObject cardPrefab;

    [SerializeField] private Transform drawDeckTransform;
    [SerializeField] private Transform discardDeckTransform;

    public enum CardColor 
    {
        Red,
        Green,
        Blue,
        Yellow,
        Black
    }

    private Dictionary<string, Color> cardColors = new Dictionary<string, Color>() 
    {
        {"Red", Color.red},
        {"Green", Color.green},
        {"Blue", Color.blue},
        {"Yellow", Color.yellow},
        {"Black", Color.black}
    };

    [SerializeField] private List<Card> drawDeck;
    [SerializeField] private List<Card> discardDeck;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one instance");
        }

        Instance = this;
    }

    private Card CreateCard(SOCard soCard, Color color, int idx)
    {
        GameObject newCard = Instantiate(cardPrefab);
        newCard.transform.SetParent(drawDeckTransform);
        newCard.transform.localPosition = Vector3.zero;

        Card card = newCard.GetComponent<Card>();
        card.SetupCardVisuals(soCard, color);
        card.SetupOrderInLayer(idx);
        
        drawDeck.Add(card);

        return card;
    }

    public void CreateDrawDeck()
    {
        int layer = 0;
        
        foreach (SOCard soCard in soCards)
        {
            Card newCard = null;
            if (soCard.type == CardType.Plus4 || soCard.type == CardType.ChangeColor)
            {
                for (int i = 0; i < 4; i++)
                {
                    newCard = CreateCard(soCard, cardColors[CardColor.Black.ToString()], layer);
                    newCard.IsFaceDown(true);   
                    layer++;
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    CardColor color = (CardColor)(i % 4);
                    newCard = CreateCard(soCard, cardColors[color.ToString()], layer);
                    newCard.IsFaceDown(true);   
                    layer++;
                }
            }
        }   
    }

    public void ShuffleDeck()
    {
        Card auxCard = null;
        for (int i = 0; i < drawDeck.Count; i++)
        {
            int randomIdx = Random.Range(i, drawDeck.Count);
            auxCard = drawDeck[i];
            drawDeck[i] = drawDeck[randomIdx];
            drawDeck[randomIdx] = auxCard;

            drawDeck[i].SetupOrderInLayer(i);
            drawDeck[randomIdx].SetupOrderInLayer(randomIdx);
        }
    }

    public Card DrawCardFromDrawDeck()
    {
        Card drewCard = drawDeck[drawDeck.Count - 1];
        drawDeck.Remove(drewCard);

        return drewCard;
    }

    public void AddCardToDiscardDeck(Card card)
    {
        discardDeck.Add(card);

        card.gameObject.transform.SetParent(discardDeckTransform);
        card.gameObject.transform.localPosition = Vector3.zero;
        card.gameObject.transform.localScale = new Vector3(Constants.CARD_WIDTH, Constants.CARD_HEIGHT, 1);

        card.SetupOrderInLayer(discardDeck.Count - 1);

        card.IsFaceDown(false);
    }

    public Card GetLastPlayedCard()
    {
        return discardDeck[discardDeck.Count - 1];
    }

    public static bool AreTwoCardsEqual(Card card1, Card card2)
    {
        if (card1.GetColor() != card2.GetColor()) return false;

        if (card1.GetCardType() != card2.GetCardType()) return false;
       
        if (card1.GetCardType() != CardType.Number) return true;

        if (card1.GetCardDigit() != card2.GetCardDigit()) return false;

        return true;
    }    
}
