using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class IA : MonoBehaviour
{
    public int gold;
    public int hp;
    public int nbHandSlotAvailable;
    public int nbHandSlots;

    public Dictionary<Tuple<int, int>, CardLogic> cards;
    public ShopSO shopSO;//il ira acheter ses cartes ici
    
    //Shop Part
    
    //public List<> strategy; il faut trouver un moyen de lui donner des compositions d'armee(en fleche, en ligne, etc)
    //public List<> focus; il faut trouver un moyen de faire une preference de target
    
    

    public void BuyCard() //Peut acheter une carte
    {
        
    }

    public void SellCard() //Peut vendre une carte 
    {
        
    }

    public void PlaceCard(CardLogic card) //Place une carte dans un des slot
    {
        
    }

    public void MakeTarget() //Pour chaque cartes en jeu, faire son target
    {
        
    }

    public void BuySlot() //Achat d'un slot (si il n'a plus de place et qu'il peut acheter)
    {

    }

    public void BuyMill() //Achat d'un moulin si il peut
    {
        
    }
    
    



}
