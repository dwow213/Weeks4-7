using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowSpawnerScript : MonoBehaviour
{
    
    //variables for sliders of snow density and speed
    public Slider snowDensity;
    public Slider snowSpeed;

    //variable for the snowflake object
    public GameObject snowflake;

    public List<GameObject> snowflakes = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //for loop that will spawn a large amount of snowflakes every frame
        //the amount spawned is dependent on the snowDensity slider
        for(int i = 0; i < snowDensity.value; i++)
        {
            //create a snowflake and add it to the snowflakes list
            snowflakes.Add(Instantiate(snowflake));
            //set the variable to the most recent object added to the list
            GameObject snowflakeObject = snowflakes[snowflakes.Count - 1];
            //randomize its initial x-position while keeping it initial y-position above the camera
            snowflakeObject.transform.position = new Vector2(Random.Range(-8, 44), 6);

            //randomize velocity of the snowflake based on the snowSpeed slider
            snowflakeObject.GetComponent<SnowflakeScript>().xVelocity = Random.Range(-5, -1) * snowSpeed.value;
            snowflakeObject.GetComponent<SnowflakeScript>().yVelocity = Random.Range(-5, -1) * snowSpeed.value;
        }
    }

    //a function that removes all snowflakes from the screen
    public void Melt()
    {
        //for loop that destroys all game objects in the scene
        for(int i = 0; i < snowflakes.Count; i++)
        {
            Destroy(snowflakes[i]);
        }

        //reset the snowflakes list
        snowflakes = new List<GameObject>();
    }
}
