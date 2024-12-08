using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseObject : MonoBehaviour
{
    public float noiseLevel = 20f;

    public void TriggerSoundEvent()
    {
        SoundManager.Instance.AddSound(noiseLevel);
    }
}
