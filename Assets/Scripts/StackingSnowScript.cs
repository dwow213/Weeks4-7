using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackingSnowScript : MonoBehaviour
{

    //list for the sprites with variants of stacked snow
    public List<Sprite> sprites;

    public GameObject ground;
    
    //variables for sliders of snow density and speed
    public Slider snowDensity;
    public Slider snowSpeed;

    //variable for holding the snow amount
    public float snowAmount;

    // Start is called before the first frame update
    void Start()
    {
        //start the amount of snow at 1
        snowAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //increase the snow amount based on the snow density slider and snow speed slider
        snowAmount += 1 * (snowDensity.value * Mathf.Pow(snowSpeed.value, 3)) * Time.deltaTime;

        //change the sprite based on how much snow it has
        //no snow
        if (snowAmount >= 1 && snowAmount <= 30)
        {
            ground.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (snowAmount >= 31 && snowAmount <= 100) //little snow
        {
            ground.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if (snowAmount >= 101 && snowAmount <= 500) //moderate snow
        {
            ground.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (snowAmount >= 501 && snowAmount <= 3000) //heavy snow
        {
            ground.GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
        else if (snowAmount > 3000) //filled with snow
        {
            ground.GetComponent<SpriteRenderer>().sprite = sprites[4];
        }
    }

    //function that resets the snow amount, snow density and snow speed
    public void Melt()
    {
        snowAmount = 1;
        snowDensity.value = 1;
        snowSpeed.value = 1;
    }
}
