using UnityEngine;

public class ShakeNoise : MonoBehaviour
{
    public float shakeThreshold = 2f;
    public float noisePerShake = 5f;
    public float checkInterval = 0.1f;

    public float shakeIntensity;

    private Rigidbody rb;
    private Vector3 lastVelocity;
    public bool isHeld = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastVelocity = Vector3.zero;
        InvokeRepeating(nameof(CheckShake), 0f, checkInterval);
    }
    
    private void CheckShake()
    {
        if (!isHeld) return;

        Vector3 velocityChange = rb.velocity - lastVelocity;
        shakeIntensity = velocityChange.magnitude / checkInterval;
        

        if (shakeIntensity > shakeThreshold)
        {
            Debug.Log("STOP I HAVE LOCOMOTIONS SICKNESS!!!");
            SoundManager.Instance.AddSound(noisePerShake);
        }

        lastVelocity = rb.velocity;
    }

    public void OnGrab()
    {
        isHeld = true;
        lastVelocity = Vector3.zero;
    }

    public void OnRelease()
    {
        isHeld = false;
    }
}
