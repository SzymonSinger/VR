using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Serialization;

public class CryingBaby : MonoBehaviour
{
    private bool isCrying = false;
    private bool happyBobo = false;
    public GameObject boboHeadphones;
    public GameObject targetHeadphones;

    private SoundManager SM;
    // Start is called before the first frame update
    void Start()
    {
        SM = FindFirstObjectByType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeMeCry()
    {
        if (!isCrying)
        {
            Debug.Log("You Made Me Cry!");
            isCrying = true;
            StartCoroutine(Crying());
        }
        else
        {
            Debug.Log("I'm already Crying");
        }
    }

    private IEnumerator Crying()
    {
        SM.AddSound(5);
        Debug.Log("I'm gonna tell mom!");
        yield return new WaitForSeconds(2);
        if (!happyBobo)
        {
            StartCoroutine(Crying());
        }
        else
        {
            Debug.Log("Okay, you can go!");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Headphone"))
        {
            boboHeadphones.SetActive(true);
            happyBobo = true;
            Destroy(targetHeadphones);
        }
    }
}
