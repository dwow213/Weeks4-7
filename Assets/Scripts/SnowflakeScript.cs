using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeScript : MonoBehaviour
{

    //variables for velocity
    public float xVelocity;
    public float yVelocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get position of snowflake
        Vector2 pos = transform.position;

        //change the position of the snowflake
        pos.x += xVelocity * Time.deltaTime;
        pos.y += yVelocity * Time.deltaTime;

        //update the position
        transform.position = pos;

        //destroy the snowflake if it is far off screen
        if (pos.x < -10 || pos.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
