using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float mediumDifficultyTime;
    [SerializeField] private float hardDifficultyTime;
    public float GameTime { get; private set; }
    public event Action IncreaseLevelDifficulty;

    private bool mediumLevel = false; 
    private bool hardLevel = false; 

    void Update()
    {
        GameTime += Time.deltaTime;

        if (!mediumLevel && GameTime >= mediumDifficultyTime)
        {
            IncreaseLevelDifficulty.Invoke();
            mediumLevel = true;
        }

        if (!hardLevel && GameTime >= hardDifficultyTime)
        {
            IncreaseLevelDifficulty.Invoke();
            hardLevel = true;
        }
    }
}
