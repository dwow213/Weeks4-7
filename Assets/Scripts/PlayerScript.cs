
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public float speed = 10;

    public List<Sprite> sprites;

    public Image image;

    public Boolean changeImage;

    // Start is called before the first frame update
    void Start()
    {
        changeImage = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos.x += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        pos.y += Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        transform.position = pos;

        if (pos.x >= 5.7 && pos.x <= 8.7 && pos.y <= 1.5 && pos.y >= -1.5)
        {
            image.enabled = true;

            if (changeImage)
            {
                image.sprite = sprites[UnityEngine.Random.Range(0, 6)];
                changeImage = false;
            }
            
            
        } 
        else
        {
            image.enabled = false;
            changeImage = true;
        }
    }
}
