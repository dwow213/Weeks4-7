using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusSpawnerScript : MonoBehaviour
{

    //variable for the timer that determines when to spawn in a bus
    public float timer;
    //variable for the bus object
    public GameObject bus;

    //variables for the snow density and snow speed sliders
    public Slider snowDensity;
    public Slider snowSpeed;

    //variable prevents multiple satisfactions of the condition to spawn buses
    public Boolean spawnCooldown;

    // Start is called before the first frame update
    void Start()
    {
        spawnCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        //increment timer by 1 every second
        timer += 1 * Time.deltaTime;

        //if timer is at 30, spawn a bus and reset timer
        if (timer >= 30)
        {
            timer = 0;
            SpawnBus();
        }

        //if timer is a multiple of 10 is is greater than 0
        if (Mathf.Floor(timer) % 10 == 0 && timer > 0 && !spawnCooldown)
        {
            //50% chance of spawning a bus
            if (UnityEngine.Random.Range(1,2) >= 1)
            {
                SpawnBus();
            }

            spawnCooldown = true;
        }

        if (Mathf.Floor(timer) % 10 != 0)
        {
            spawnCooldown = true;
        }
    
    }

    //function for spawning a bus
    void SpawnBus()
    {
        //instantiates a bus and sets its position offscreen on the road in the background
        GameObject busObject = Instantiate(bus);
        busObject.transform.position = new Vector2(-15, 3.5f);

        //set up the bus's snow density and speed sliders
        busObject.GetComponent<BusScript>().snowDensity = snowDensity;
        busObject.GetComponent<BusScript>().snowSpeed = snowSpeed;
    }
}
