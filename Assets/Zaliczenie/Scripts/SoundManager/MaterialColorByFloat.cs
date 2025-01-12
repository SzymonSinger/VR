using System;
using UnityEngine;

public class MaterialColorByFloat : MonoBehaviour
{
    public Material targetMaterial; // Assign the material in the Inspector
    private float value = 0f; // The float value controlling the color (0-100)
    private SoundManager SM;

    private void Start()
    {
        SM = GetComponent<SoundManager>();
    }

    private void Update()
    {
        value = SM.currentSoundLevel;
        // Ensure the value is clamped between 0 and 100
        value = Mathf.Clamp(value, 0f, 100f);

        Color newColor;
        if (value < 50f)
        {
            newColor = Color.Lerp(Color.green, Color.yellow,value / 50f);
        }
        else
        {
            // Yellow to Red (0-50)
            newColor = Color.Lerp(Color.yellow, Color.red, (value - 50f) / 50f);
        }
        // Calculate the color based on the value
        

        // Apply the color to the material
        targetMaterial.color = newColor;
    }
}