using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{

    //list for the people prefabs and sprites for them
    public List<GameObject> people = new List<GameObject>();
    public List<Sprite> sprites = new List<Sprite>();

    //variable for the person object
    public GameObject person;

    // Start is called before the first frame update
    void Start()
    {
        //randomize the people at the program's start up
        createPeople();
    }

    //function that creates the people, randomizing their sprite and incrementing their position
    public void createPeople()
    {
        //for loop that will instantiate a maximum of 20 people and determine their position and sprite
        for (int i = 0; i < people.Count; i++)
        {

            //destroy the game object in the index to set up for making new ones or making it empty
            Destroy(people[i]);

            //50% chance of instantiating a person
            if (Random.Range(0, 2) == 1)
            {
                //the current index will hold a person prefab
                people[i] = Instantiate(person);

                //x-position will go further to the right the larger the index is
                float x = -6.4f + 1.4f * i;
                //y-position will be constant
                float y = -1;

                //set the person's position
                people[i].transform.position = new Vector3(x, y);

                //randomly select a sprite for the person to have
                //if the person is near a bench, make it possible for them to have sitting sprites
                if (i == 3)
                {
                    people[i].GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 8)];

                }
                else //if they are not, don't make it possible for them to have sitting sprites
                {
                    people[i].GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 5)];
                }

            }
            else //50% chance failed and the index will be set to null
            {
                people[i] = null;
            }

        }
    }
}
