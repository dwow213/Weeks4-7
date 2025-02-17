using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class TankScript : MonoBehaviour
{

    public GameObject turret;
    public GameObject tankBody;
    public GameObject bullet;

    public AudioSource sound;

    public Slider speed;
    public int selectedSprite;

    public List<Sprite> sprites;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)turret.transform.position;

        pos.x += Input.GetAxisRaw("Horizontal") * speed.value * Time.deltaTime;
        pos.y += Input.GetAxisRaw("Vertical") * speed.value * Time.deltaTime;

        transform.position = pos;

        turret.transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletObject = Instantiate(bullet);
            bulletObject.transform.position = turret.transform.position;
            bulletObject.transform.right = direction;
            sound.Play();
        }

        tankBody.GetComponent<SpriteRenderer>().sprite = sprites[selectedSprite % 5];
    }

    public void changeSprite()
    {
        selectedSprite += 1;
    }
}
