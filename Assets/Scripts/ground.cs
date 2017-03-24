using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{

    private AudioSource source;
<<<<<<< HEAD
    Vector3 lastPos;
    public Transform obj; // drag the object to monitor here 
    float threshold = 0.0f; // minimum displacement to recognize.

    void Start()
    {
        lastPos = obj.position;
=======
    float lastPosY;
    public Transform obj; // drag the object to monitor here 
    float threshold = -5f; // minimum displacement to recognize.
    private bool elevatorLeftGround = false;

    void Start()
    {
        lastPosY = obj.position.y;
>>>>>>> elevatorSensor
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
<<<<<<< HEAD
        source.Play();
=======
        source.volume = 0.15F;
        source.Play();

>>>>>>> elevatorSensor
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        Vector3 offset = obj.position - lastPos;
        if (offset.y > threshold)
        {
            lastPos = obj.position;
            fadeOut();


        }
        else if (offset.x < -threshold)
        {
            lastPos = obj.position;
            source.Play();
=======
        float offsetY = obj.position.y - lastPosY;

        if (offsetY > threshold && !elevatorLeftGround)
        {
            fadeOut();
        }
        else if (offsetY < 10 && elevatorLeftGround)
        {
            fadeIn();
>>>>>>> elevatorSensor
        }
    }

    void fadeOut()
    {
<<<<<<< HEAD
        source.volume -= 0.3F * Time.deltaTime;
        if (source.volume <= 0)
            source.Stop();
        print(source.volume);
=======
        source.volume -= 0.05F * Time.deltaTime;
        if (source.volume <= 0)
        {
            elevatorLeftGround = true;
            source.Stop();
        }
    }

    void fadeIn()
    {
        print("volume" + source.volume);
        if (source.volume < 0.15)
        {
            source.volume += 0.05F * Time.deltaTime;

        }
        else
        {
            elevatorLeftGround = false;
        }
        if (!source.isPlaying)
        {
            source.Play();
        }
>>>>>>> elevatorSensor
    }
}
