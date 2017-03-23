using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using System.Linq;

public class upDownElevator : MonoBehaviour
{

    //get up down button
    public Button upButton;
    public float speed = 0.02F;
    private float distance = 0;

    private Vector3 endMarkerUp = new Vector3(0F, 69F, 0F);
    private Vector3 endMarkerDown = new Vector3(0F, 0.1F, 0F);

    // Moving flags
    private bool moveUp = false;
    private bool moveDown = false;

    // Voice Recognition
	KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
		print ("START");
        //Create keywords for keyword recognizer
        keywords.Add("go up", () =>
        {
            // action to be performed when this keyword is spoken
			print("up added");
            UpCalled();
        });

        keywords.Add("stop", () =>
        {
            // action to be performed when this keyword is spoken
            StopCalled();
        });

        keywords.Add("down", () =>
        {
            // action to be performed when this keyword is spoken
            DownCalled();
        });

		keywordRecognizer = new KeywordRecognizer (keywords.Keys.ToArray ());
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start ();
    }

    void KeywordRecognizer_OnPhraseRecognized (PhraseRecognizedEventArgs args)
    {
		System.Action keywordAction;

		if (keywords.TryGetValue(args.text, out keywordAction)) {
			keywordAction.Invoke ();
		}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveDown = false;
            moveUp = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            moveUp = false;
            moveDown = false;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            moveUp = false;
            moveDown = true;
        }

        if (moveUp == true)
        {
            if (distance < endMarkerUp.y)
            {
                transform.Translate(Vector3.up * speed, Space.Self);
                distance = distance + Vector3.up.y * speed;
            }
        }
        else if (moveDown == true)
        {
            if (distance > endMarkerDown.y)
            {
                transform.Translate(Vector3.down * speed, Space.Self);
                distance = distance + Vector3.down.y * speed;
            }
        }
    }

    void UpCalled()
    {
        print("UP");
        moveDown = false;
        moveUp = true;
    }

    void StopCalled()
    {
        print("STOP");
        moveDown = false;
        moveUp = false;
    }

    void DownCalled()
    {
        print("DOWN");
        moveDown = true;
        moveUp = false;
    }

}