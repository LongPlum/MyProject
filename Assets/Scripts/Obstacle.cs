using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Obstacle : PoolableMonobehaviour
{
    public ObstaclePool Pool { get; private set; }
    public GameObject ObstaclePrefab { get; private set; }
    public bool IsSetup { get; private set; }

    private Transform gameObjectTransform;

    public Obstacle(GameObject obsPrefab,ObstaclePool pool, Transform parentTransform)
    {
        Pool = pool;
        gameObjectTransform = parentTransform;
        ObstaclePrefab = obsPrefab;
        obsPrefab.transform.position = gameObjectTransform.position;
        ObstaclePrefab.SetActive(false);
    }

    public override void Setup(Vector3 spawnPoint)
    {
        if (IsSetup)
            return;

        ObstaclePrefab.transform.position = spawnPoint;
        ObstaclePrefab.SetActive(true);
        IsSetup = true;
    }

    public override void Release()
    {
        ObstaclePrefab.transform.position = gameObjectTransform.position;
        ObstaclePrefab.SetActive(false);
        IsSetup = default;
    }
}

