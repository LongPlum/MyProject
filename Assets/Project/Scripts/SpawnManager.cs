
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [SerializeField] private ObstaclePool obstaclePool;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private PlayerCollision playerCollision;
    [SerializeField] private SpawnManagerScriptableObj[] spawnManagerOptions;

    private Config Options;
    private GameObject currentGameObject;
    private ObstaclePoolItem[] obstacleEnumValues;
    private float timer;
    private int difficultyLevel;


    private ObstaclePoolItem ItemToSpawn => obstacleEnumValues[UnityEngine.Random.Range(0, obstaclePool.GetPoolItemLength)];

    void Start()
    {
        playerCollision.OnPlayerCollision += SpawnStop;
        levelManager.IncreaseLevelDifficulty += LevelUpDifficulty;
        difficultyLevel = 0;
        Options = spawnManagerOptions[difficultyLevel].GetConfig();
        obstacleEnumValues = (ObstaclePoolItem[])Enum.GetValues(typeof(ObstaclePoolItem));
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= Options.spawnTimerOption)
        {
            currentGameObject = obstaclePool.TakeObstacle(ItemToSpawn);
            currentGameObject.GetComponent<DirectionMovement>().obstacleMoveSpeed = Options.objectsMoveSpeedOption;
            currentGameObject.transform.position = new Vector3(UnityEngine.Random.Range(-4, 4), 0.5f, UnityEngine.Random.Range(66, 76));

             timer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.CompareTag("Obstacle"))
        {
            obstaclePool.ReleaseObstacle(other.gameObject);
        }
    }


    private void LevelUpDifficulty()
    {
        difficultyLevel++;
        Options = spawnManagerOptions[difficultyLevel].GetConfig();
    }

    private void SpawnStop(float delay)
    {
        timer -= delay;
    }

}