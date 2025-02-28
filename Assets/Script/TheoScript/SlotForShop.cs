using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotForShop : ASlot
{
    [HideInInspector] public TextMeshProUGUI textForWidgetGold;
    private Shop shop;
    
    public void Awake()
    {
        shop = transform.parent.parent.parent.parent.parent.GetComponent<Shop>();
    }

    public void Start()
    {
        textForWidgetGold = shop.textForWidgetGold;
    }
    
    
    protected override void CardChangePosition(PointerEventData eventData)
    {
            shop.OnDrop(eventData); 
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        GameObject card = eventData.pointerDrag;
        CardDragHandler cardDragged = card.GetComponent<CardDragHandler>();
        cardDragged.originalContainerSlot = shop.transform;
        if (transform.childCount < 2)
        {
            GameObject newCard = Instantiate(card, transform);
        }
        Debug.Log(cardDragged.originalContainerSlot.GetComponent<Shop>().gold); 
        shop.Subtractgold(card.GetComponent<CardLogic>().value);
        Debug.Log(cardDragged.originalContainerSlot.GetComponent<Shop>().gold); 
        if (shop.gold < 0)
        {
            cardDragged.canBeDragged = false;
        }

    }

    public override void RepairdCard(CardDragHandler cardDragged)
    {
        Debug.Log(cardDragged.originalContainerSlot);
        shop.Addgold(cardDragged.GetComponent<CardLogic>().value);
        cardDragged.transform.SetParent(cardDragged.originalParent);
        cardDragged.canBeDragged = true;
        cardDragged.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        Debug.Log(cardDragged.originalContainerSlot.GetComponent<Shop>().gold);
    }

    public override void DestroyCard(PointerEventData eventData)
    {
        Debug.Log("SlotForShop cannot destroy Card");
    }
}

//Methode trouvé pour instantiate une nouvelle carte lors de l'achat d'une carte
//1) Avoir deux cartes dans le meme slot -> en drag une -> si mal passé, la reposer, sinon des qu'on en reprends
// une autre, verifie si elle est toute seule, on instantie une nouvelle si oui
// on peut ajouter une setActive si on veut s'embeter a que ce soit "vide" quand on prends la carte
//2) (debile) on instantie la carte si elle est prise, on la detruit si ca ne va pas