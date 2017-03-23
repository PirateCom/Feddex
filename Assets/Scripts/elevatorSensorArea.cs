using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorSensorArea : MonoBehaviour
{


    public GameObject leftDoor;
    public GameObject rightDoor;

    public float hoverForce = 12f;
    private float distance = 30f;

    private float lerpTime = 50;
    private float currentLerpTime = 50;

    Vector3 startPosLeft = new Vector3(-0.5f, 0f, -1f);
    Vector3 endPosLeft = new Vector3(0.5f, 0f, -1f);

    Vector3 startPosRight = new Vector3(2.5f, 0f, -1f);
    Vector3 endPosRight = new Vector3(1.5f, 0f, -1f);

    public AudioSource sourceOpen;
    public AudioSource sourceClose;

    void Start()
    {
    }

    void Awake()
    {
        var sourceOpen = GetComponent<AudioSource>();
        var sourceClose = GetComponent<AudioSource>();
       
        sourceOpen = GetComponent<AudioSource>();
        sourceClose = GetComponent<AudioSource>();
        sourceOpen.volume = 0.2F;
        sourceClose.volume = 0.2F;
    }

    // Update is called once per frame
    void Update()
    {
        currentLerpTime += 1;
        if (currentLerpTime >= lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        float Perc = currentLerpTime / lerpTime;
        leftDoor.transform.localPosition = Vector3.Lerp(startPosLeft, endPosLeft, Perc);
        rightDoor.transform.localPosition = Vector3.Lerp(startPosRight, endPosRight, Perc);
    }


    void OnTriggerEnter(Collider other)
    {


        endPosLeft = new Vector3(-0.5f, 0f, -1f);
        startPosLeft = new Vector3(0.5f, 0f, -1f);

        endPosRight = new Vector3(2.5f, 0f, -1f);
        startPosRight = new Vector3(1.5f, 0f, -1f);

        currentLerpTime = 0;

        sourceOpen.Play();

        // leftDoor.transform.localPosition = new Vector3 (-0.5f, 0f,-1f);
        // rightDoor.transform.localPosition = new Vector3 (2.5f, 0f, -1f);


    }
    void OnTriggerStay(Collider other)
    {
        //other.GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
    }

    void OnTriggerExit(Collider other)
    {
        sourceClose.Play();
        currentLerpTime = Time.deltaTime;
        if (currentLerpTime >= lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        startPosLeft = new Vector3(-0.5f, 0f, -1f);
        endPosLeft = new Vector3(0.5f, 0f, -1f);

        startPosRight = new Vector3(2.5f, 0f, -1f);
        endPosRight = new Vector3(1.5f, 0f, -1f);

        currentLerpTime = 0;
    }
}
