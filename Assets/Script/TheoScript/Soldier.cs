using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public SoldierSO soldierSO;
    public int health;
    public int armour;
    public int speed;
    public int damage;
    
    public Soldier target;
   
    public bool alive;

    public void Awake()
    {
        health = soldierSO._health;
        armour = soldierSO._armour;
        speed = soldierSO._speed;
        damage = soldierSO._damage;
    }
    
    public void Die()
    {
        alive = false;
        //rends le perso en ragdoll;
    }

    public void Attack()
    {
        target.health -= damage - target.armour;
    }

    public void Relive()
    {
        
        health = soldierSO._health;
        alive = true;
    }
}
