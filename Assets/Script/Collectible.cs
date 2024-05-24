using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{   

    int myScore = 5;

    void Collected()
    {
        Debug.Log("I got collected");
        Destroy(gameObject);
    }


    //this happens when something touches me
    private void OnCollisionEnter(Collision collision)
    {
        //check if the object touched has a "Player" tag
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().IncreaseScore(myScore);
            Collected();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
