using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class BasementVoiceActionsController : MonoBehaviour {
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	KeywordRecognizer keywordRecognizer;
	public bool lightsFlag = false;
	public bool leavelFlag = false;

	// Use this for initialization
	void Start () {
		keywords.Add("lights", LightsOn);
		keywords.Add("leave", LeaveRoom);

		keywordRecognizer = new KeywordRecognizer (keywords.Keys.ToArray ());
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start ();

	}
	
	// Update is called once per frame
	void Update () {
		if (leavelFlag == true) {
			SceneManager.LoadScene ("menu", LoadSceneMode.Single);
		}	
	}

	void LightsOn() {
		print ("Let there be lights!");
		lightsFlag = true;
	}
	void LeaveRoom() {
		print ("Leave the room!");
		leavelFlag = true;
	}
}
