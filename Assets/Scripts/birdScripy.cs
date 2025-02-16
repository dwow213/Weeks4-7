using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class birdScripy : MonoBehaviour
{

    float timer = 0;
    public birdScripy bird;
    public SpriteRenderer birdSr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;

        if (timer >= 1)
        {
            birdSr.enabled = false;
            timer = 0;
            bird.enabled = false;
        }
    }
}
