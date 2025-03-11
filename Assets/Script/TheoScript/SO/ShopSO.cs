using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopSO", menuName = "SO/Shop")]
public class ShopSO : ScriptableObject
{
    public int _addSlotShopPrice;
    public float _multiplicatorSlotShopPrice;
    public int _startingGold;
    public int _gainGoldIfWin;
    public int _gainGoldIfLose;
    public int _goldByMill;
    public List<ListCard> _cardsAvailable;

}
