using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardsManager : MonoBehaviour
{

    [SerializeField] private SOCard[] soCards;
    [SerializeField] private GameObject cardPrefab;

    private Dictionary<string, Color> cardColors = new Dictionary<string, Color>()
    {
        {"Red", Color.red},
        {"Green", Color.green},
        {"Blue", Color.blue},
        {"Yelow", Color.yellow}
    };

    [SerializeField] private List<Card> drawDeck;

    private void Start()
    {

        GameObject newCard = Instantiate(cardPrefab);
        Card card = newCard.GetComponent<Card>();
        //card.SetupCardVisuals(soCards[13], cardColors[0]);


        //drawDeck.Add(card);
    }


}
