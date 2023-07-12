
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [SerializeField] private ObstaclePool obstaclePool;
    [SerializeField] private SpawnManagerScriptableObj spawnManagerOptions;

    private Config Options;
    private GameObject currentGameObject;
    private ObstaclePoolItem[] obstacleEnumValues;
    private float timer;


    private ObstaclePoolItem itemToSpawn => obstacleEnumValues[UnityEngine.Random.Range(0, obstaclePool.GetPoolItemLength)];

    void Start()
    {
        Options = spawnManagerOptions.GetConfig();
        obstacleEnumValues = (ObstaclePoolItem[])Enum.GetValues(typeof(ObstaclePoolItem));
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= Options.spawnTimerOption)
        {
            currentGameObject = obstaclePool.TakeObstacle(itemToSpawn);
            currentGameObject.GetComponent<DirectionMovement>().obstacleMoveSpeed = Options.objectsMoveSpeedOption;
            currentGameObject.transform.position = new Vector3(UnityEngine.Random.Range(-4, 4), 0.5f, UnityEngine.Random.Range(66, 76));

            timer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        obstaclePool.ReleaseObstacle(other.gameObject);
    }

    // разобратся с addrasable
    // system input поменять на подписку 
    // написать нормальную фабрику
    // сделать увеличение уровней сложности со временем игры с помощью массива скриптабл обж
    // коллизия игрока с обстаклами




    // исправил record +, https://stackoverflow.com/questions/64749385/predefined-type-system-runtime-compilerservices-isexternalinit-is-not-defined
    //  obstaclerelease доделать +
    // obstacle ms выделить в отдельный компонент и прокинуть +

}