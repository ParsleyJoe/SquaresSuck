using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int pistolDamage = 20;
    public int shotgunDamage = 20;
    public float bulletForce = 10f; // Force Applied when object hit
    public float shotgunForce = 20f; // Force Applied when object hit

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WeaponType currentWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>().currentWeaponType;
        if (!collision.CompareTag("PowerUP"))
        {
            Destroy(gameObject);
        }
        // Do damage
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (currentWeapon == WeaponType.Pistol)
            {
                collision.GetComponent<Enemy>().TakeDamage(pistolDamage);
            }
            else if (currentWeapon == WeaponType.Shotgun)
            {
                collision.GetComponent<Enemy>().TakeDamage(shotgunDamage);
            }
            Debug.Log("Hit " + collision.name);
        }

        // Adds force to the object hit
        Rigidbody2D gameobjectRb = gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D collisionRb = collision.GetComponent<Rigidbody2D>();
        if (collisionRb != null)
        {
            Vector2 ForceTowards;
            if (currentWeapon == WeaponType.Shotgun)
            {
                ForceTowards = new Vector2(shotgunForce, 0);
            }
            else
            {
                ForceTowards = new Vector2(bulletForce, 0);
            }

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
}
