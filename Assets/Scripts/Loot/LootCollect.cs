using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LootType
{
    HealthUP, Revolver, Shotgun
}

public class LootCollect : MonoBehaviour
{
    public LootType thisLootType;
    public int healthUpIncrease = 20;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLootType(string name)
    {
        if (name == "HealthUP")
        {
            thisLootType = LootType.HealthUP;
        }
        else if (name == "RevolverDrop")
        {
            thisLootType = LootType.Revolver;
        }
        else if (name == "ShotgunDrop")
        {
            thisLootType = LootType.Shotgun;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            PlayerCombat playerCombat = collision.gameObject.GetComponent<PlayerCombat>();
            if (thisLootType == LootType.HealthUP)
            {
                playerCombat.AddHealth(healthUpIncrease);
            }
            else if (thisLootType == LootType.Revolver)
            {
                playerCombat.SetWeapon(WeaponType.Pistol);
            }
            else if (thisLootType == LootType.Shotgun)
            {
                playerCombat.SetWeapon(WeaponType.Shotgun);
            }
            Destroy(gameObject);
        }
    }
}
