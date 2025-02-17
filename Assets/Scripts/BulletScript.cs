using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 15;
    }

    // Update is called once per frame
    void Update()
    {


        transform.position += transform.right * speed * Time.deltaTime;

        Vector2 pos = transform.position;

        if (pos.x > 10 || pos.x < -10 || pos.y > 7 || pos.y < -7)
        {
            Destroy(gameObject);
        }
    }
}
