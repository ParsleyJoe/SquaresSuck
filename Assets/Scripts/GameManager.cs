using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject enemyPrefab;
    public GameObject HealthUP;
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreUI;
    public int score;
    public float startSpawningIn;
    public float spawnBombsEvery; // ___ seconds
    public float spawnEnemiesEvery;
    private float spawnEnemiesTime;
    public float spawnBoundX;
    public float spawnBombY = 1;
    public float spawnEnemyY = -2.3f;
    public float spawnPowerUpEvery; // ___ seconds
    private float currentPowerUpSpawnTime;
    private int enemiesInScene;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBombs", startSpawningIn, spawnBombsEvery);
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;

        spawnEnemiesTime = spawnEnemiesEvery;
        player = GameObject.FindGameObjectWithTag("Player");
        currentPowerUpSpawnTime = spawnPowerUpEvery;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnEnemiesTime <= 0)
        {
            SpawnEnemies();
            spawnEnemiesTime = spawnEnemiesEvery;
        }
        else
        {
            spawnEnemiesTime -= Time.deltaTime;
        }

        if (Time.timeScale == 0)
        {
            gameOverScreen.SetActive(true);
        }

    }

    void SpawnBombs()
    {
        Vector3 spawnAt = new Vector3(Random.Range(spawnBoundX, -spawnBoundX), spawnBombY , 0); // Spawn at random X value same Y and z doesn't matter
        Instantiate(bombPrefab, spawnAt, bombPrefab.transform.rotation);
    }

    void SpawnEnemies()
    {
        Vector3 spawnAt = new Vector3(Random.Range(spawnBoundX, -spawnBoundX), spawnEnemyY, 0);
        Instantiate(enemyPrefab, spawnAt, enemyPrefab.transform.rotation);
    }

    void SpawnPowerUP()
    {
        Vector3 spawnAt = new Vector3(Random.Range(spawnBoundX, -spawnBoundX), spawnEnemyY, 0);
        Instantiate(HealthUP, spawnAt, HealthUP.transform.rotation);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreUI.SetText("Score: " + score);
    }
}
