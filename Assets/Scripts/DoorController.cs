using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var trackedController = GetComponent<SteamVR_TrackedController> ();
		if (trackedController == null) {
			trackedController = gameObject.AddComponent<SteamVR_TrackedController> ();
		}
		trackedController.TriggerClicked += new ClickedEventHandler (DoClick);
	}
	
	void DoClick(object sender, ClickedEventArgs e) {
		Debug.Log ("DoorController::TriggerClicked");
	}
}
