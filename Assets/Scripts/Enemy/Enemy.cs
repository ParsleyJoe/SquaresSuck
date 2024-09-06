using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem hitParticles;
    public int maxHealth;
    public float speed = 5.0f;
    public GameObject pistolPrefab;
    public int enemyScoreAdd = 20;
    private int currentHealth;
    private GameObject player;
    private Rigidbody2D enemyRb;
    private bool facingLeft = false;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        enemyRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Dead();
        }

    }

    private void FixedUpdate()
    {
        Vector2 MoveTowards = player.transform.position - gameObject.transform.position;
        MoveTowards.Normalize();
        enemyRb.AddForce(MoveTowards * speed);

        if (enemyRb.velocity.x > 0 && facingLeft)
        {
            Flip();
        }
        if (enemyRb.velocity.x < 0 && !facingLeft)
        {
            Flip();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(hitParticles, transform.position, hitParticles.transform.rotation);
        // Add force oppossite side of hit
    }

    void Flip()
    {
        gameObject.transform.Rotate(0, 180, 0);
        facingLeft = !facingLeft;
    }


    void Dead()
    {
        GetComponent<LootBag>().InstantiateLoot(gameObject.transform.position);
        Destroy(gameObject);
        gameManager.AddScore(enemyScoreAdd);
    }
}
