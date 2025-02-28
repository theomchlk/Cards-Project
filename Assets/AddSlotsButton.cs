using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddSlotsButton : MonoBehaviour
{
    public Shop shop;
    public Hand hand;
    public TextMeshProUGUI textValue;
    
    public void Start()
    {
        textValue.text = shop.addSlotShopPrice + " PO";
        
    }

    public void AddSlot()
    {
        if (shop.gold >= shop.addSlotShopPrice)
        {
            if (hand.nbSlotsAvailable < hand.maxNbSlotsAvailable)
            {
                shop.Subtractgold(shop.addSlotShopPrice);
                shop.addSlotShopPrice = Mathf.CeilToInt(shop.addSlotShopPrice * shop.multiplicatorSlotShopPrice);
                textValue.text = shop.addSlotShopPrice + " PO";
                hand.AddSlot();
            }
            else
            {
                textValue.text = "MAX";
            }
        }
    }
}
