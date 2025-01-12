using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundLevelUI : MonoBehaviour
{
    private Slider soundSlider;
    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindFirstObjectByType<SoundManager>();
        soundSlider = GetComponentInChildren<Slider>();
        soundSlider.maxValue = soundManager.maxSoundLevel;
    }

    private void Update()
    {
        soundSlider.value = soundManager.currentSoundLevel;
    }
}
