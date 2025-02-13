using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //variable for the speed of movement
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //initial speed is 5
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //get position of camera
        Vector3 pos = transform.position;

        //move the camera left to right with arrow keys
        pos.x += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

        //reset camera position if it goes too far to the left
        if (pos.x < 0)
        {
            pos.x = 0;
        }

        //reset camera position if it goes to far to the right
        if (pos.x > 18.5)
        {
            pos.x = 18.5f;
        }

        //ensure that the camera can see the objects on the scene
        pos.z = -10;

        //update camera position
        transform.position = pos;
    }
}
