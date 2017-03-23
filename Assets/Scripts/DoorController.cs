using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour {
	private SteamVR_Controller.Device applicationMenuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;
	public bool applicationMenuButtonUp = false;
	private SteamVR_Controller.Device controller {
		get {
			return SteamVR_Controller.Input ((init)trackedObject.index);
		}
	}
	private SteamVR_TrackedObject trackedObject;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller == null) {
			Debug.Log("Controller not initialized!");
			return;
		}

		applicationMenuButtonUp = controller.GetPressUp (applicationMenuButton);
		if (applicationMenuButtonUp == true) {
			Debug.Log ("Door pressed");
			SceneManager.LoadScene ("menu", LoadSceneMode.Single);
		}
	}
}
