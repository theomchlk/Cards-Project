using System.Collections;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour, IContainsSlots
{
    [SerializeField] private Transform[] _cardCanComesFrom; 
    public Transform[] cardCanComesFrom => _cardCanComesFrom;
    

    public bool ContainsSlot(Transform container)
    {
        return _cardCanComesFrom.Contains(container);
    }

    public PlayerSO playerSO;
    private int hp;
    private bool isDead;
    private int gold;

    public void Awake()
    {
        isDead = false;
        hp = playerSO._hp;
        gold = playerSO._gold;
    }
    public void Addgold(int amount)
    {
        gold += amount;
    }

    public void Subtractgold(int amount)
    {
        gold -= amount;
    }

    public void Losehp()
    {
        hp -= playerSO._damageTaken;
    }
    
}
