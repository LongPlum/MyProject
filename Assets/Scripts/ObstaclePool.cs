using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Linq;

public class ObstaclePool : MonoBehaviour
{

    [SerializeField] private int poolSize;
    [SerializeField] private List<GameObject> pooledGameObjects = new List<GameObject>();

    private Dictionary<ObstaclePoolItem, Stack<GameObject>> dictionaryPool = new();
    private Dictionary<ObstaclePoolItem, Func<GameObject>> factory = new();


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
            var poolKey = item.GetComponent<IPoolableMonobehaviour>().poolKey;
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
            var poolKey = item.GetComponent<IPoolableMonobehaviour>().poolKey;

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
                go.SetActive(true);
                return go;
            }

            GameObject factoryGo = factory[obstacleType]();
            factoryGo.SetActive(true);
            return factoryGo;
        }
        throw new ArgumentException($"{obstacleType} does not exist");
    }

    public void ReleaseObstacle(GameObject obstacleToRelease)
    {
        var poolableArray = obstacleToRelease.GetComponents<IPoolableMonobehaviour>();
        if (poolableArray != null && poolableArray.Length > 0)
        {
            var poolKey = poolableArray[0].poolKey;
            foreach (var item in poolableArray)
            {
                item.Release();
            }
            obstacleToRelease.transform.position = transform.position;
            obstacleToRelease.SetActive(false);
            dictionaryPool[poolKey].Push(obstacleToRelease);
        }
    }


    /*
    private async void LoadPrefabs()
    {
        List<AsyncOperationHandle<GameObject>> prefabHandles = new List<AsyncOperationHandle<GameObject>>();
        int index = 0;

        foreach (AssetReference prefabReference in obstacleAssets)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(prefabReference);
            prefabHandles.Add(handle);
        }

        foreach (AsyncOperationHandle<GameObject> handle in prefabHandles)
        {
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                var bruh = handle.Result;
                
            }
        }
    }
    */
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

