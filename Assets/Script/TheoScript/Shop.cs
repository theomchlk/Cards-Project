using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class Shop : AContainsSlots, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ShopSO shopSO;
    public TextMeshProUGUI textForShop;
    public TextMeshProUGUI textForWidgetGold;
    public int nbSlotShop;
    public int addSlotShopPrice;
    public float multiplicatorSlotShopPrice;
    public int gold;
    public int gainGoldIfWin;
    public int gainGoldIfLose;
    public List<ListCard> cardsAvailable;
    
    //field for widget
    
    // permet de l'activer/desactiver
    
    // field from this script
    
    private CanvasGroup canvasGroup;

    public void Awake()
    {
        addSlotShopPrice = shopSO._addSlotShopPrice;
        multiplicatorSlotShopPrice = shopSO._multiplicatorSlotShopPrice;
        gold = shopSO._startingGold;
        gainGoldIfWin = shopSO._gainGoldIfWin;
        gainGoldIfLose = shopSO._gainGoldIfLose;
        cardsAvailable = shopSO._cardsAvailable;
        
        canvasGroup = GetComponent<CanvasGroup>();
        
        
    }

    public void Start()
    {
        textForWidgetGold.text = gold.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.dragging)
        {
            if (this.ContainsSlot(eventData.pointerDrag.GetComponent<CardDragHandler>().originalContainerSlot))
            {
                CardLogic card = eventData.pointerDrag.GetComponent<CardLogic>();
                canvasGroup.alpha = 0.5f;
                textForShop.gameObject.SetActive(true);
                textForShop.text = card.value * card.percentageLessWhenRefund / 100 + " PO";

            }
            
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetComponent<CanvasGroup>().alpha = 1f;
        textForShop.gameObject.SetActive(false);
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            CardDragHandler cardDragged = eventData.pointerDrag.GetComponent<CardDragHandler>();
            if (this.ContainsSlot(eventData.pointerDrag.GetComponent<CardDragHandler>().originalContainerSlot))
            {
                Debug.Log(cardDragged.originalParent.GetComponent<SlotForShop>() != null);
                if (cardDragged.originalParent.GetComponent<SlotForShop>() == null)
                {
                    CardLogic card = eventData.pointerDrag.GetComponent<CardLogic>();
                    Addgold(( card.value * card.percentageLessWhenRefund) / 100);
                    Debug.Log(gold.GetType());
                    textForShop.gameObject.SetActive(false);
                    transform.GetComponent<CanvasGroup>().alpha = 1;
                    Debug.Log(gold);
                    cardDragged.originalParent.GetComponent<ASlot>().DestroyCard(eventData);
                }
            }
            

        }
    }
    

    public void Addgold(int amount)
    {
        gold += amount;
        textForWidgetGold.text = gold.ToString();
    }

    public void Subtractgold(int amount)
    {
        gold -= amount;
        textForWidgetGold.text = gold.ToString();
    }


    
}