using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : MonoBehaviour
{
    [SerializeField] Tower tower;
    int damage;
    void Start()
    {
        damage = tower.GetDamage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetDamage()
    {
        return damage;
    }
}
