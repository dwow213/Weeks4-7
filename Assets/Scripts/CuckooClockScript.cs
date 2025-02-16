using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuckooClockScript : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip clip;
    float timer = 0;
    int chimes = 1;
    int chimeTimes = 0;
    Boolean chiming = false;

    public birdScripy bird;
    public SpriteRenderer birdSr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = transform.eulerAngles;
        rot.z += 10 * Time.deltaTime;
        timer += 10 * Time.deltaTime;

       // Debug.Log(rot.z);

        if (timer >= 30 || chiming) 
        {
            Debug.Log("cuck");

            bird.enabled = true;
            birdSr.enabled = true;
            chiming = true;

            if (chimeTimes < chimes && audioSource.isPlaying == false)
            {
                audioSource.PlayOneShot(clip);
                Debug.Log("Chimes: " + chimeTimes);
                chimeTimes += 1;
            }
            else if (chimeTimes >= chimes)
            {
                chimes += 1;
                chiming = false;
                chimeTimes = 0;
                Debug.Log("reset");
                Debug.Log("Max Chimes: " + chimes);
            }

            timer = 0;

        }

        transform.eulerAngles = rot;


    }
}
