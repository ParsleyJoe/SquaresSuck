using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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
    public float spawnEnemiesLimit = 1.0f;
    public float decrementSpawnRateBy = 0.3f;
    public int enemiesInSceneLimit = 10;
    private float decrementCountdown = 30f;
    private float currentDecrementTime;
    private int enemiesInScene;
    private float spawnEnemiesTime;
    public float spawnBoundX;
    public float spawnBombY = 1;
    public float spawnEnemyY = -2.3f;
    public float spawnPowerUpEvery; // ___ seconds
    private float currentPowerUpSpawnTime;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnBombs), startSpawningIn, spawnBombsEvery);
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
        score = 0;

        spawnEnemiesTime = spawnEnemiesEvery;
        player = GameObject.FindGameObjectWithTag("Player");
        currentPowerUpSpawnTime = spawnPowerUpEvery;
        currentDecrementTime = decrementCountdown;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (spawnEnemiesTime <= 0 && enemiesInScene <= enemiesInSceneLimit)
        {
            SpawnEnemies();
            spawnEnemiesTime = spawnEnemiesEvery;
        }
        else
        {
            spawnEnemiesTime -= Time.deltaTime;
        }

        if (currentDecrementTime <= 0)
        {
            spawnEnemiesEvery -= decrementSpawnRateBy;
            currentDecrementTime = decrementCountdown;
            Debug.Log("Enemies now spawn every " + spawnEnemiesEvery + " seconds");
        }
        else
        {
            currentDecrementTime -= Time.deltaTime;
        }

        if (Time.timeScale == 0)
        {
            gameOverScreen.SetActive(true);
        }

    }

    // Spawn Everything 
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

    // Restart Button Logic
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Adding Score
    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreUI.SetText("Score: " + score);
    }
}
