using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 30;
    [Tooltip("Adds amount to maxHitpoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] ParticleSystem deathVFX;

    int currentHitPoints = 0;

    Enemy enemy;
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        int damage = other.GetComponent<BulletInfo>().GetDamage();
        ProcessHit(damage);
    }

    private void ProcessHit(int damage)
    {
        currentHitPoints -= damage;

        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            var Explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(Explosion.gameObject, 2f);
            //maxHitPoints += difficultyRamp; // Burası zorluğu artırır.
            enemy.RewardGold();
        }
    }

    public int GetCurrentHitpoints() => currentHitPoints;
}
