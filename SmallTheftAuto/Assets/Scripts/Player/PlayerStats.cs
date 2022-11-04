using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{
    public int money;

    public int health;

    public int score;
    
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
