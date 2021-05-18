using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] int playerHealth = 3;

    int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHealth( int damageAmount = 1)
    {
        playerHealth -= damageAmount;
    }

    public bool IsALive()
    {
        bool isAlive = playerHealth < 1;
        return isAlive;
    }

    public int GetCurrentHealth()
    {
        return playerHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
