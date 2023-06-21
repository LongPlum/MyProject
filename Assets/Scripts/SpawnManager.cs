
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] ObstaclesArray = new GameObject[0];

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
     

    }

    void Update()
    {
        
    }
}
