using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Source/Pool/PoolPreset", fileName = "PoolPreset", order = 0)]
public class MyScriptableObj :ScriptableObject

{
    [SerializeField] private string da;
    [SerializeField] private int net;



    public Config GetConfig()
    {
        return new Config() { da = this.da, net = this.net };
    }
}

public struct Config
{
    public string da;
    public int net;
}


