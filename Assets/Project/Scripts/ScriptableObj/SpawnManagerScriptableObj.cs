using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Source/SpawnManager/SpawnManagerPreset", fileName = "SpawnManagerPreset", order = 0)]
public class SpawnManagerScriptableObj : ScriptableObject

{
    [SerializeField] private float spawnTimerOption;
    [SerializeField] private float objectsMoveSpeedOption;

    public Config GetConfig()
    {
        return new Config() { spawnTimerOption = this.spawnTimerOption, objectsMoveSpeedOption = this.objectsMoveSpeedOption };
    }
}
public record Config
{
    public float spawnTimerOption { get; init; }
    public float objectsMoveSpeedOption { get; init; }
}

namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}


