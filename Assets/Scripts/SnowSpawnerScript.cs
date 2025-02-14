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
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //for loop that will spawn a large amount of snowflakes every frame
        //the amount spawned is dependent on the snowDensity slider
        for(int i = 0; i < 5 * snowDensity.value; i++)
        {
            //create a snowflake
            GameObject snowflakeObject = Instantiate(snowflake);
            //randomize its initial x-position while keeping it initial y-position above the camera
            snowflakeObject.transform.position = new Vector2(Random.Range(-8, 44), 6);

            //randomize velocity of the snowflake based on the snowSpeed slider
            snowflakeObject.GetComponent<SnowflakeScript>().xVelocity = Random.Range(-5, -1) * snowSpeed.value;
            snowflakeObject.GetComponent<SnowflakeScript>().yVelocity = Random.Range(-5, -1) * snowSpeed.value;
        }
    }
}
