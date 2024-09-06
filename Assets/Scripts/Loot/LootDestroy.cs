using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDestroy : MonoBehaviour
{
    [SerializeField] private float destroyLootIn;
    private float timeLeftToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        timeLeftToDestroy = destroyLootIn;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeftToDestroy <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            timeLeftToDestroy -= Time.deltaTime;
        }
    }
}
