using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundLevelUI : MonoBehaviour
{
    private Slider soundSlider;

    private void Awake()
    {
        soundSlider = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        if (SoundManager.Instance != null)
        {
            soundSlider.value = SoundManager.Instance.GetCurrentSoundLevel();
        }
    }
}
