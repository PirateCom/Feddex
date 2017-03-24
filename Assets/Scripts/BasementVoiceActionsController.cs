using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;
using System.Linq;

public class BasementVoiceActionsController : MonoBehaviour {
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	KeywordRecognizer keywordRecognizer;
	public bool lightsFlag = false;
	public bool leavelFlag = false;
	public GameObject spotLight;
	public GameObject bedLight;
	public GameObject doorLight;
	public GameObject backRoomLight;
	public GameObject sideWallLight;
	const float lightValue = 0.5F;

	// Use this for initialization
	void Start () {
		keywords.Add("lights on", LightsOn);
		keywords.Add("lights off", LightsOn);
		keywords.Add("back", LeaveRoom);

		keywordRecognizer = new KeywordRecognizer (keywords.Keys.ToArray ());
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start ();

	}
	
	// Update is called once per frame
	void Update () {
		if (leavelFlag == true) {
			SceneManager.LoadScene ("menu", LoadSceneMode.Single);
		}
		if (lightsFlag == true) {
			ChangeLight (spotLight, 0);
			ChangeLight (bedLight, lightValue);
			ChangeLight (doorLight, lightValue);
			ChangeLight (sideWallLight, lightValue);
			ChangeLight (backRoomLight, lightValue);
		}
		if (lightsFlag == false) {
			ChangeLight (backRoomLight, 0);
			ChangeLight (sideWallLight, 0);
			ChangeLight (doorLight, 0);
			ChangeLight (bedLight, 0);
			ChangeLight (spotLight, 8F);
		}
	}

	void LightsOn() {
		print ("Let there be lights!");
		lightsFlag = !lightsFlag;
	}
	void LeaveRoom() {
		print ("Leave the room!");
		leavelFlag = true;
	}
	void ChangeLight(GameObject lightObject, float intensity) {
		lightObject.GetComponent<Light> ().intensity = intensity;
	}
	void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args) {
		System.Action keywordAction;
		if (keywords.TryGetValue (args.text, out keywordAction)) {
			keywordAction.Invoke();
		}
	}
}
