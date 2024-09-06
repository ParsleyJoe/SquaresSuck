using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 20;
    public float bulletForce = 10f; // Force Applied when object hit

    // Update is called once per frame
    void Update()
    {
        rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("PowerUP"))
        {
            Destroy(gameObject);
        }
        // Do damage
        Rigidbody2D gameobjectRb = gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D collisionRb = collision.GetComponent<Rigidbody2D>();
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerCombat>().TakeDamage(damage);
            Debug.Log("Hit " + collision.name);

            
            if (collisionRb != null)
            {
                Vector2 ForceTowards = new Vector2(bulletForce, 0);
                if (gameobjectRb.velocity.x > 0)
                {
                    collisionRb.AddForce(ForceTowards, ForceMode2D.Impulse);
                }
                else if (gameobjectRb.velocity.x < 0)
                {
                    collisionRb.AddForce(-ForceTowards, ForceMode2D.Impulse);
                }
            }
        }

        // Adds force to the object hit
    }
}
