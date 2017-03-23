using UnityEngine;

public class Ground : MonoBehaviour
{

    private AudioSource source;
    Vector3 lastPos;
    public Transform obj; // drag the object to monitor here 
    float threshold = 0.0f; // minimum displacement to recognize.

    void Start()
    {
        lastPos = obj.position;
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = obj.position - lastPos;
        if (offset.y > threshold)
        {
            print("aaa");
            lastPos = obj.position;
            fadeOut();


        }
        else if (offset.x < -threshold)
        {
            lastPos = obj.position;
            source.Play();
            print("BBBB");
        }
    }

    void fadeOut()
    {
        source.volume -= 0.3F * Time.deltaTime;
        if (source.volume <= 0)
            source.Stop();
        print(source.volume);
    }
}
