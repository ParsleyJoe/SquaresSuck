using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { None, Pistol, Shotgun }

public class PlayerWeaponManager : MonoBehaviour
{
    WeaponType currentWeapon;
    PlayerCombat playerCombat;
    GameManager gameManager;
    [SerializeField] private GameObject revolver;
    [SerializeField] private GameObject shotgun;

    private void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeWeapon(WeaponType changeTo)
    {
        switch (changeTo)
        {
            case WeaponType.None:
                revolver.SetActive(false);
                shotgun.SetActive(false);
                break;
            case WeaponType.Pistol:
                revolver.SetActive(true);
                shotgun.SetActive(false);
                break;
            case WeaponType.Shotgun:
                shotgun.SetActive(true);
                revolver.SetActive(false);
                break;
            default:
                Debug.Log("Weapons System Got Messed Up");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // change weapons
    }
}
