using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidCameraController : MonoBehaviour {
	public float speedMultiplier = 1.5F;

	void Start() {
		//gameObject.AddComponent<Renderer>();
	}

	void Update () {
		//print (gameObject.GetComponent<Renderer>().isVisible);

	}

	void LateUpdate () {
		//print (gameObject.GetComponent<Renderer>().isVisible);
	}

	void OnBecameInvisible() {
//		speed /= 10;
	}

	void OnBecameVisible() {
		//print (speed);
//		speed *= 10;
	}


}
