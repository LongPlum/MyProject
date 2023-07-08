using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Obstacle : MonoBehaviour, IPoolableMonobehaviour
{
    [ShowInInspector] public ObstaclePoolItem poolKey { get; set; }

    public  void Release()
    {
    }
}

