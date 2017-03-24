using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{

    private AudioSource source;
    float lastPosY;
    public Transform obj; // drag the object to monitor here 
    float threshold = 0.2f; // minimum displacement to recognize.

    private bool elevatorLeftGround = false;

    void Start()
    {
        lastPosY = obj.position.y;
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0.4F;
        source.Play();     
    }

    // Update is called once per frame
    void Update()
    {

        float offsetY = obj.position.y - lastPosY;
		if (obj.position.y - lastPosY > 0.1  ) {
			if (offsetY > threshold && !elevatorLeftGround) {
				fadeOut ();
			} else if (offsetY < 10 && elevatorLeftGround) {
				fadeIn ();
			}
		}
    }

    void fadeOut()
    {		
        source.volume -= 0.05F * Time.deltaTime;
        if (source.volume <= 0)
        {
            elevatorLeftGround = true;
            source.Stop();
        }
    }

    void fadeIn()
    {
        if (source.volume < 0.4)
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
    }
}
