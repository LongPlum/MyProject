using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Sirenix.OdinInspector;
using Sirenix;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using System.Linq;

public class ObstaclePool : MonoBehaviour
{
    private string assetGroupKey = "ObstacleKey";

    [SerializeField] private int poolSize;
    [SerializeField] private List<GameObject> pooledGameObjects = new ();

    private Dictionary<ObstaclePoolItem, Stack<GameObject>> dictionaryPool = new();
    private Dictionary<ObstaclePoolItem, Func<GameObject>> factory = new();

    private List<GameObject> obstacleOnScene = new ();

    public IReadOnlyCollection<GameObject> ObstacleOnScene
    {
        get { return obstacleOnScene.AsReadOnly(); }
    }


    private void Awake()
    {
        LoadAssetGroup();
    }

    private void Start()
    {

        var enumValues = Enum.GetNames(typeof(ObstaclePoolItem));

        foreach (var item in pooledGameObjects)
        {
            if (!enumValues.Contains(item.name))
            {
                Debug.LogError($"There is no {item.name} type", gameObject);
            }
        }

        foreach (var item in enumValues)
        {
            if (pooledGameObjects.Any(gameObject => gameObject.name == item))
                continue;
            Debug.LogError($"There is no {item} object", gameObject);
        }


        foreach (var item in pooledGameObjects)
        {
            var poolKey = item.GetComponent<PoolableKey>().poolKey;
            if (factory.ContainsKey(poolKey))
            {
                Debug.LogError($"Factory already have {item.name} key", gameObject);
                continue;
            }
            var parent = new GameObject($"Pool_{item.name}");
            parent.transform.SetParent(transform);
            factory.Add(poolKey, () =>
            {
                var go = Instantiate(item);
                go.transform.SetParent(parent.transform);
                go.SetActive(false);
                return go;
            });
        }


        foreach (var item in pooledGameObjects)
        {
            var poolKey = item.GetComponent<PoolableKey>().poolKey;

            if (dictionaryPool.ContainsKey(poolKey))
            {
                Debug.LogError($"Dictionary Pool already have {item.name} key", gameObject);
                continue;
            }

            var pooledStack = new Stack<GameObject>(poolSize);
            for (int i = 0; i < poolSize; i++)
            {
                if (factory.TryGetValue(poolKey, out var build))
                {
                    pooledStack.Push(build());
                }
                else
                {
                    Debug.LogError($"????", gameObject);
                }
            }
            dictionaryPool.Add(poolKey, pooledStack);
        }
    }

    public GameObject TakeObstacle(ObstaclePoolItem obstacleType)
    {
        if (dictionaryPool.TryGetValue(obstacleType, out Stack<GameObject> obstacleStack))
        {
            if (obstacleStack.Count > 0)
            {
                GameObject go = obstacleStack.Pop();
                obstacleOnScene.Add(go);
                go.SetActive(true);
                return go;
            }

            GameObject factoryGo = factory[obstacleType]();
            obstacleOnScene.Add(factoryGo);
            factoryGo.SetActive(true);
            return factoryGo;
        }
        throw new ArgumentException($"{obstacleType} does not exist");
    }

    public void ReleaseObstacle(GameObject obstacleToRelease)
    {
        var poolKeyComp = obstacleToRelease.GetComponentInParent<PoolableKey>();
        if (poolKeyComp != null)
        {
            var poolableArray = obstacleToRelease.GetComponentsInParent<IPoolableMonobehaviour>();
            if (poolableArray != null && poolableArray.Length > 0)
            {
                foreach (var item in poolableArray)
                {
                    item.Release();
                }
            }
            poolKeyComp.gameObject.transform.position = transform.position;
            poolKeyComp.gameObject.SetActive(false);
            obstacleOnScene.Remove(poolKeyComp.gameObject);
            dictionaryPool[poolKeyComp.poolKey].Push(poolKeyComp.gameObject);
        }
        else
            Destroy(obstacleToRelease);
    }



    private async void LoadAssetGroup()
    {
        // Загрузка группы ассетов по имени группы
        AsyncOperationHandle<IList<GameObject>> handle = Addressables.LoadAssetsAsync<GameObject>(assetGroupKey, null);
        // Ожидание завершения загрузки
        await handle.Task;

        // Обработка результата
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            IList<GameObject> assets = handle.Result;
            // Выполнение действий с загруженными ассетами
            foreach (GameObject asset in assets)
            {
               // Debug.Log(asset.name);
            }
        }
        else
        {
            Debug.LogError("Failed to load asset group: " + handle.OperationException);
        }

        // Освобождение ресурсов
        Addressables.Release(handle);
    }

    public int GetPoolItemLength => pooledGameObjects.Count;

}


public enum ObstaclePoolItem
{
    Obctacle_FallenTreeRock,
    Obstacle_CarTire,
    Obstacle_CarTireFallenTree,
    Obstacle_FallenTree,
    Obstacle_Rock,
    Obstacle_RockWall
}

