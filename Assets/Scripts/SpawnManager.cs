
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class SpawnManager : MonoBehaviour
{
    [SerializeField] private ObstaclePool obstaclePool;
    [SerializeField] private GameObject spawnPoint;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }

    private void SpawnObstacle()
    {
        
    }
}