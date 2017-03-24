using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;
using System.Linq;

public class MenuVoiceController : MonoBehaviour {
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	KeywordRecognizer keywordRecognizer;
	public bool spiderRoomFlag = false;
	public bool elevatorRoomFlag = false;
	// Use this for initialization
	void Start () {
		keywords.Add("room", SpiderRoom);
		keywords.Add("eleven", ElevatorRoom);

		keywordRecognizer = new KeywordRecognizer (keywords.Keys.ToArray ());
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		if (spiderRoomFlag == true) {
			SceneManager.LoadScene ("spider", LoadSceneMode.Single);
		}
		if (elevatorRoomFlag == true) {
			SceneManager.LoadScene ("elevator", LoadSceneMode.Single);
		}
	}
	void SpiderRoom() {
		spiderRoomFlag = true;

	}
	void ElevatorRoom() {
		elevatorRoomFlag = true;
	}

	void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args) {
		System.Action keywordAction;
		if (keywords.TryGetValue (args.text, out keywordAction)) {
			keywordAction.Invoke();
		}
	}
}
