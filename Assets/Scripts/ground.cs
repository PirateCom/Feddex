using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{

    private AudioSource source;
    Vector3 lastPos;
    public Transform obj; // drag the object to monitor here 
    float threshold = 0.0f; // minimum displacement to recognize.
    private bool elevatorLeftGround = false;

    void Start()
    {
        lastPos = obj.position;
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0.2F;
        source.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = obj.position - lastPos;

        lastPos = obj.position;

        if (offset.y > threshold)
        {
            elevatorLeftGround = true;
            
            fadeOut();
        }
        else if (-0.15> offset.y && offset.y < -0.1 && elevatorLeftGround)
        {
            fadeIn();
        }
    }

    void fadeOut()
    {
        source.volume -= 0.05F * Time.deltaTime;
        if (source.volume <= 0)
            source.Stop();
    }

    void fadeIn()
    {
        if(source.volume<0.3)
            source.volume += 0.05F * Time.deltaTime;
        if (!source.isPlaying)
            source.Play();
    }
}
