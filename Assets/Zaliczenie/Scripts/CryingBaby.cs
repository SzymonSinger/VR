using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Serialization;

public class CryingBaby : MonoBehaviour
{
    private bool isCrying = false;
    public bool happyBobo = false;
    public GameObject boboHeadphones;
    public GameObject targetHeadphones;
    public AudioClip crying;
    public AudioClip party;
    public GameObject hint;
    
    private SoundManager SM;
    private Animator anim;
    private AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        SM = FindFirstObjectByType<SoundManager>();
        anim = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
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
            hint.SetActive(true);
            AS.Stop();
            AS.clip = crying;
            AS.Play();
            anim.SetBool("isCrying", true);
            StartCoroutine(Crying());
        }
        else
        {
            Debug.Log("I'm already Crying");
        }
    }

    private IEnumerator Crying()
    {
        SM.AddSound(10);
        Debug.Log("I'm gonna tell mom!");
        yield return new WaitForSeconds(2);
        if (!happyBobo)
        {
            StartCoroutine(Crying());
        }
        else
        {
            AS.Stop();
            AS.clip = party;
            AS.Play();
            anim.SetBool("isCrying", false);
            anim.SetBool("isHappy", true);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isCrying)
        {
            if (other.gameObject.CompareTag("Headphone"))
            {
                boboHeadphones.SetActive(true);
                happyBobo = true;
                Destroy(targetHeadphones);
            }
        }
    }
}
