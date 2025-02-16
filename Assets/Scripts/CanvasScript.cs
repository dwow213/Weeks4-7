using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if the canvas is hidden, make it visible
            if (gameObject.GetComponent<Canvas>().enabled == false)
            {
                gameObject.GetComponent<Canvas>().enabled = true;
            }
            else //if the canvas is visible, hide it
            {
                gameObject.GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
