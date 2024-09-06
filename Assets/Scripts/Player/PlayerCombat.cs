using BarthaSzabolcs.Tutorial_SpriteFlash;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int maxHealth;
    public GameObject firePoint;
    public GameObject revolver;
    public GameObject shotgun;
    public HealthBar healthBar;
    private int currentHealth;
    public GameObject bullet;
    public float timeBtwShots = 2.0f;
    public ParticleSystem hitParticles;
    public int collisionDamage = 10;
    public int powerUPHealthIncrease = 40;
    public WeaponType currentWeaponType;
    public AudioClip powerUpSound;
    private AudioSource audioSource;
    private float currentTimeBtwShots;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        audioSource = GetComponent<AudioSource>();
        currentWeaponType = WeaponType.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentTimeBtwShots <= 0)
        {
            Shoot();
            currentTimeBtwShots = timeBtwShots;
        }
        else
        {
            currentTimeBtwShots -= Time.deltaTime;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Shoot()
    {
        if (currentWeaponType != WeaponType.None)
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Instantiate(hitParticles, transform.position, hitParticles.transform.rotation);
    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Dead");
        Time.timeScale = 0; // Freeze the game
    }

    public void SetWeapon(WeaponType changeTo)
    {
        currentWeaponType = changeTo;
        Debug.Log("Weapons is " + currentWeaponType);
        audioSource.PlayOneShot(powerUpSound);

        if (currentWeaponType == WeaponType.None)
        {
            revolver.SetActive(false);
            shotgun.SetActive(false);
        }
        if (currentWeaponType == WeaponType.Pistol)
        {
            revolver.SetActive(true);
            shotgun.SetActive(false);
        }
        if (currentWeaponType == WeaponType.Shotgun)
        {
            revolver.SetActive(false);
            shotgun.SetActive(true);
        }
    }

    public void AddHealth(int health)
    {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
        audioSource.PlayOneShot(powerUpSound);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    
}
