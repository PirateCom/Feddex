using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;
using System.Linq;

public class ElevatorVoiceController : MonoBehaviour {
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	KeywordRecognizer keywordRecognizer;
	public bool leavelFlag = false;

	// Use this for initialization
	void Start () {
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

	void LeaveRoom() {
		print ("Leave the room!");
		leavelFlag = true;
	}
	void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args) {
		System.Action keywordAction;
		if (keywords.TryGetValue (args.text, out keywordAction)) {
			keywordAction.Invoke();
		}
	}
}
