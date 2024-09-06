using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public GameObject FirePoint;
    public GameObject bulletPrefab;
    public float timeBtwShots;
    private float currentTimeBtwShots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimeBtwShots <= 0)
        {
            Attack();
            currentTimeBtwShots = timeBtwShots;
        }
        else
        {
            currentTimeBtwShots -= Time.deltaTime;
        }
    }

    void Attack()
    {
        Instantiate(bulletPrefab, FirePoint.transform.position, FirePoint.transform.rotation);
    }
}
