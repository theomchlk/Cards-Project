using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CardShopDisplayer : MonoBehaviour
{
    public ShopSO shopSO;
    public GameObject tableShop;
    public GameObject cardLine;
    public List<Transform> cardShops;


    public void Awake()
    {
        foreach (Transform cardShop in cardShops)
        {
            cardShop.parent.GetComponent<Shop>().shopSO = shopSO;
        }
    }


    public void Start()
    {
        UpdateShop();
    }
    
    [ContextMenu("Update CardShop")]
    public void UpdateShop()
    {
        foreach (Transform cardShop in cardShops)
        {
            
            ClearShop(cardShop);
            UpdateSlotShop(cardShop);
        }
    }

    private void UpdateSlotShop(Transform cardShop)
    {
        foreach (ListCard cardList in shopSO._cardsAvailable)
        {
            int i = 1;
            GameObject newTableShop = Instantiate(tableShop, cardShop);
            newTableShop.name = "CardLevel" + i;
            
            Debug.Log(newTableShop.transform.GetChild(0).GetComponent<TextMeshProUGUI>() != null);
            
            newTableShop.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Cartes Niveau " + 1;
            Transform table = newTableShop.transform.GetChild(1);
            
            foreach (GameObject _card in cardList)
            {
                int j = 1;
                GameObject newCardLine = Instantiate(cardLine, table);
                newCardLine.name = "CardLine" + j;
                
                GameObject card = Instantiate(_card, newCardLine.transform.GetChild(0));
                newCardLine.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    card.GetComponent<CardLogic>().cardName;
                newCardLine.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = 
                    card.GetComponent<CardLogic>().cardDescription;
                newCardLine.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = 
                    card.GetComponent<CardLogic>().value + " PO";
                

                j++;
            }

            i++;
        }
    }

    
    private void ClearShop(Transform cardShop)
    {
        Debug.Log("Clear Shop");
        for (int i = cardShop.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(cardShop.GetChild(i).gameObject);
        }
    }
    
    
    
}
 