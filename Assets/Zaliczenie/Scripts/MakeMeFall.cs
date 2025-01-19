using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMeFall : MonoBehaviour
{
    private Rigidbody rb;

    private AudioSource audiosrc;

    private bool dontLoop = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiosrc = GetComponent<AudioSource>();
    }

    public void MakeMeFallPlease()
    {
        rb.isKinematic = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!dontLoop)
        {
            if (other.gameObject.CompareTag("Floor"))
            {
                audiosrc.Play();
                dontLoop = true;
            }
        }
    }
}
