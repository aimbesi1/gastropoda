using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script modified from https://www.youtube.com/watch?v=zit45k6CUMk

public class BackgroundParallax : MonoBehaviour
{
    private float length, startpos; // length and start position of the sprite
    public GameObject cam;
    public float parallaxEffect; // How much parallax effect we're going to apply 

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x; // First find the start position of the background
        length = GetComponent<SpriteRenderer>().bounds.size.x; // Then get the length of the background
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect)); // How far we've moved relative to the camera
        float dist = (cam.transform.position.x * parallaxEffect); // How far we have moved in the world space

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z); // Move the camera

        if (temp > (startpos + length))
        {
            startpos += length;
        }
        else if (temp < (startpos - length)){
        startpos -= length;
        }
    }
}