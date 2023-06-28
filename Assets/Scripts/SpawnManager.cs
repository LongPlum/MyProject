
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class SpawnManager : MonoBehaviour
{
    //[SerializeField] private AssetReference[] obstacleAssets;
    [SerializeField] private GameObject[] obstacleAssets = new GameObject[5];
    //[SerializeField] private DespawnGround despawnscript;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // LoadPrefabs();
       // despawnscript.SpawnGround += 
    }

     void Update()
    {
            
    }

    private void SpawnObstacle()
    { 
    
    
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