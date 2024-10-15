using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private List<Card> hand;

    private CardsManager cardsManager;

    private float totalInitialCards = 7;

    private void Start()
    {
        cardsManager = FindAnyObjectByType<CardsManager>();
    }

    private void AddCardToPlayerHand(Card card)
    {
        hand.Add(card);
    }

    private void RemoveCardFromPlayerHand(Card card)
    {
        hand.Remove(card);
    }

    private void InitializePlayerHand()
    {
        //Repetir 7 veces robar carta

        for (int i = 0; i < totalInitialCards; i++)
        {
            //Card drewCard = CardsManager.DrawCardFromDeck();
           //AddCardToPlayerHand(CardsManager.DrawCardFromDeck();
        }
    }

}
