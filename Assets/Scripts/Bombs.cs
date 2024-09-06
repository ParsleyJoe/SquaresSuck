using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Bombs : MonoBehaviour
{
    public int fuseTime;
    public ParticleSystem explosionParticles;
    public GameObject explosionCenter;
    public float explosionRadius = 5.0f;
    public int explosionDamage = 20;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(routine:Explosion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(fuseTime);
        Explode();
    }

    void Explode()
    {
        Destroy(gameObject);
        DoDamage();
        Instantiate(explosionParticles, gameObject.transform.position, explosionParticles.transform.rotation);
    }

    void DoDamage()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(explosionCenter.transform.position, explosionRadius);
        foreach (var nearbyObject in hitColliders)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Add explosion Force
            }
            TakesExplosionDamage damageableObject = nearbyObject.GetComponent<TakesExplosionDamage>();
            if (damageableObject != null)
            {
                damageableObject.ExplosionDamage(explosionDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(explosionCenter.gameObject.transform.position, explosionRadius);
    }
    
}
