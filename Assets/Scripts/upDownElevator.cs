using UnityEngine;
using UnityEngine.UI;

public class upDownElevator : MonoBehaviour
{

    //get up down button
    public Button upButton;
    public float speed = 0.2F;
    private float distance = 0;

    public Vector3 endMarker = new Vector3(0F, 69F, 19.3F);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (distance < endMarker.y)
        {
            transform.Translate(Vector3.up * speed, Space.Self);
            distance = distance + Vector3.up.y * speed;
        }
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

}