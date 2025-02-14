using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusScript : MonoBehaviour
{

    //variable for determining whether it is moving horizontally or vertically
    public Boolean horizontalMov;

    //variables for velocity
    public float xVelocity;
    public float yVelocity;

    //variables for the snow density and snow speed sliders
    public Slider snowDensity;
    public Slider snowSpeed;

    //variable for the horizontal direction of the bus
    public int horizontalDir;

    //array list for the bus's appearance
    public List<Sprite> sprites;

    // Start is called before the first frame update
    void Start()
    {
        //start the bus moving horizontally
        horizontalMov = true;
        horizontalDir = 1;

        //set the initial velocity to 8
        xVelocity = 8;
        yVelocity = -8;
    }

    // Update is called once per frame
    void Update()
    {
        //get position of bus
        Vector2 pos = transform.position;

        //if the bus is moving horizontally
        if (horizontalMov)
        {
            //move the bus either to the left or right with a velocity based on snow density and snow speed
            pos.x += (horizontalDir * xVelocity - horizontalDir * (snowDensity.value / 5 + snowSpeed.value)) * Time.deltaTime;
        }
        else
        {
           //move the bus downwards with a velocity based on snow density and snow speed
            pos.y += (yVelocity + (snowDensity.value / 5 + snowSpeed.value)) * Time.deltaTime;
        }

        //if the bus has reached the turn of the road in the background
        if (pos.x >= 26 && pos.y == 3.5)
        {
            //reset x-position to be near the border
            pos.x = 26;
            //cause the bus to move vertically
            horizontalMov = false;
            //set up the bus to move to the left when it finishes moving vertically
            horizontalDir = -1;
        }

        //if the bus has reach the turn of the vertical road into the foreground road
        if (pos.y <= -3.5 && pos.x == 26)
        {
            //reset y-position to be near the border
            pos.y = -3.5f;
            //cause the bus to move horizontally
            horizontalMov = true;
        }

        //update position of the bus
        transform.position = pos;

        //destroy the bus if it is far off screen
        if (pos.x < -15)
        {
            Destroy(gameObject);
        }

    }
}
