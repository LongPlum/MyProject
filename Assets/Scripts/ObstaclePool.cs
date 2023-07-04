using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{


    public Transform PoolablesParent { get; private set; }

    [SerializeField] private List<GameObject> pooledGameObjects = new List<GameObject>();
    private List<PoolableMonobehaviour> obstaclePool = new List<PoolableMonobehaviour>();

    private void Start()
    {
        PoolablesParent = transform;
        for (int a = 0; a < pooledGameObjects.Count; a++)
        {
            for (int i = 0; i < 2; i++)
            {
                obstaclePool.Add(new Obstacle(Instantiate(pooledGameObjects[a]), this, PoolablesParent));
            }
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


