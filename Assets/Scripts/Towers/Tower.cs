using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        SetAttackPoints();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetAttackPoints()
    {
        if (tag == "Cannon")
        {
            damage = PlayerPrefController.GetCannonAP();
        }
        else if (tag == "DoubleCannon")
        {
            damage = PlayerPrefController.GetDoubleCannonAP();
        }
        else if (tag == "Gatling")
        {
            damage = PlayerPrefController.GetGatlingAP();
        }
        else if (tag == "Flamer")
        {
            damage = PlayerPrefController.GetFlamerAP();
        }
    }

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }

    public int GetDamage() 
    {
        return damage;   
    }
}
