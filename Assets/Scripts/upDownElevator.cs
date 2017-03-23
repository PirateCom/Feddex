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

    public Vector3 endMarkerUp = new Vector3(0F, 69F, 0F);
    public Vector3 endMarkerDown = new Vector3(0F, -2.5F, 0F);

    // Moving flags
    private bool moveUp = false;
    private bool moveDown = false;

    // Voice Recognition
	KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    private AudioSource source;

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

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveDown = false;
            moveUp = true;
            source.Play();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            moveUp = false;
            moveDown = false;
            source.Stop();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            moveUp = false;
            moveDown = true;
            source.PlayDelayed(1);
        }

        if (moveUp == true)
        {
            if (distance < endMarkerUp.y)
            {
                transform.Translate(Vector3.up * speed, Space.Self);
                distance = distance + Vector3.up.y * speed;
            }
            else
            {
                source.Stop();
            }
        }
        else if (moveDown == true)
        {
            if (distance > endMarkerDown.y - 1)
            {
                transform.Translate(Vector3.down * speed, Space.Self);
                distance = distance + Vector3.down.y * speed;               
            }
            else
            {
                source.Stop();
            }
        }
    }

    void UpCalled()
    {
        print("UP");
        moveDown = false;
        moveUp = true;
        source.PlayDelayed(1);
    }

    void StopCalled()
    {
        print("STOP");
        moveDown = false;
        moveUp = false;
        source.Stop();
    }

    void DownCalled()
    {
        print("DOWN");
        moveDown = true;
        moveUp = false;
        source.PlayDelayed(1);
    }

}