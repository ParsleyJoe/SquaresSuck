using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakesExplosionDamage : MonoBehaviour
{
    public void ExplosionDamage(int damage)
    {
        if (gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<PlayerCombat>().TakeDamage(damage);
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
