using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnFloorTrigger : MonoBehaviour
{
    public float noiseLevel = 20f;
    private bool ActionTriggered = false;
    public void TriggerSoundEvent()
    {
        Debug.Log($"OUCH IT HURTS!");
        SoundManager.Instance.AddSound(noiseLevel);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag($"Floor"))
        {
            if (ActionTriggered == false)
            {
                TriggerSoundEvent();
                ActionTriggered = true;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag($"Floor"))
        {
            ActionTriggered = false;
        }
    }
}
