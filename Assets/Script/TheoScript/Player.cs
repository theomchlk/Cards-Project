using System.Collections;
using System.Linq;
using UnityEngine;

public class Player : AContainsSlots
{
    

    public PlayerSO playerSO;
    private int hp;
    private bool isDead;


    public void Awake()
    {
        isDead = false;
        hp = playerSO._hp;

    }
    

    public void Losehp()
    {
        hp -= playerSO._damageTaken;
    }
    
}
