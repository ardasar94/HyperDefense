using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 20f;
    Transform target;

    void Start()
    {

    }

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closetTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closetTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        if (target == null)
        {
            target = closetTarget;
        }
        else if ((Vector3.Distance(transform.position, target.transform.position) < range && target.GetComponent<EnemyHealth>().GetCurrentHitpoints() > 0))
        {
            return;
        }
        else
        {
            target = closetTarget;
        }
        
    }

    private void AimWeapon()
    {
        if (FindObjectsOfType<Enemy>().Length == 0)
        {
            Attack(false);
            return; 
        }
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if (targetDistance < range)
        {
            Attack(true);
            
        }
        else
        {
            Attack(false);
        }

    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles;
        //var emissionModule = projectileParticles.emission;
        emissionModule.gameObject.SetActive(isActive);
        //emissionModule.enabled = isActive;
    }
}
