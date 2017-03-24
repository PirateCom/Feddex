using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using System.Linq;

public class elevatorSensorArea : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
	public Collider player;

    public float hoverForce = 12f;

    private float lerpTime = 50;
    private float currentLerpTime = 50;

    Vector3 startPosLeft = new Vector3(-0.5f, 0f, -1f);
    Vector3 endPosLeft = new Vector3(0.5f, 0f, -1f);

    Vector3 startPosRight = new Vector3(2.5f, 0f, -1f);
    Vector3 endPosRight = new Vector3(1.5f, 0f, -1f);

    public AudioSource sourceOpen;
    public AudioSource sourceClose;

	// Voice Recognition
	KeywordRecognizer keywordRecognizer;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    void Start()
    {
		sourceOpen.volume = 1F;
		sourceClose.volume = 1F;

		keywords.Add("open doors", () =>
			{
				// action to be performed when this keyword is spoken
				openDoors();
			});

		keywords.Add("close doors", () =>
			{
				// action to be performed when this keyword is spoken
				closeDoors();
			});

		keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start();
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

	void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keywordAction;

		if (keywords.TryGetValue(args.text, out keywordAction))
		{
			keywordAction.Invoke();
		}

	}


    void OnTriggerEnter(Collider other)
    {
		print ("trigger enter");
		if (other != player) {
			return;
		}
		openDoors ();


    }
    void OnTriggerStay(Collider other)
    {
        //other.GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
    }

    void OnTriggerExit(Collider other)
    {
		print ("trigger enter");
		if (other != player) {
			return;
		}
		closeDoors ();
    }


	void openDoors() {
		endPosLeft = new Vector3(-0.5f, 0f, -1f);
		startPosLeft = new Vector3(0.5f, 0f, -1f);

		endPosRight = new Vector3(2.5f, 0f, -1f);
		startPosRight = new Vector3(1.5f, 0f, -1f);

		currentLerpTime = 0;

		sourceOpen.Play();

		// leftDoor.transform.localPosition = new Vector3 (-0.5f, 0f,-1f);
		// rightDoor.transform.localPosition = new Vector3 (2.5f, 0f, -1f);
	}

	void closeDoors() {
		sourceClose.Play();
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
