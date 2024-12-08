using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    [Header("Sound Settings")]
    public float maxSoundLevel = 100f;
    public float decayRate = 5f;
    public float decayDelay = 5f;
    public float currentSoundLevel = 0f;

    private float decayTimer = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        if (currentSoundLevel > 0)
        {
            decayTimer += Time.deltaTime;

            if (decayTimer >= decayDelay)
            {
                currentSoundLevel -= decayRate * Time.deltaTime;
                currentSoundLevel = Mathf.Clamp(currentSoundLevel, 0, maxSoundLevel);
            }
        }

        if (currentSoundLevel >= maxSoundLevel)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log($"Player Lost! Too Loud!");
    }

    public void AddSound(float amount)
    {
        currentSoundLevel += amount;
        currentSoundLevel = Mathf.Clamp(currentSoundLevel, 0, maxSoundLevel);
        decayTimer = 0;
    }

    public float GetCurrentSoundLevel()
    {
        return currentSoundLevel;
    }
    
}
