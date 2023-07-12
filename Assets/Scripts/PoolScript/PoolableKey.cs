using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoolableKey : MonoBehaviour
{
    public ObstaclePoolItem poolKey { get => key; }
    [SerializeField] private ObstaclePoolItem key;
}
