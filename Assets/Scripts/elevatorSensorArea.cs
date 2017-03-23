using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorSensorArea : MonoBehaviour {


	public GameObject leftDoor;
	public GameObject rightDoor;

	public float hoverForce = 12f;

	private Vector3 startPos;
	private Vector3 endPos;
	private float distance = 30f;

	private float lerpTime = 5;
	private float currentLerpTime = 0;

	void start(){
		//leftDoor = GameObject.FindGameObjectWithTag("leftDoor");
		//rightDoor = GameObject.FindGameObjectWithTag("rightDoor");

		startPos = leftDoor.transform.position;
		endPos = leftDoor.transform.position + Vector3.up * distance;
	}

	void update (){
		currentLerpTime = Time.deltaTime;
		if (currentLerpTime >= lerpTime) {
			currentLerpTime = lerpTime;
		}
	}

	void OnTriggerEnter (Collider other){
		print("Entered collider");



		Vector3 startPosLeft = new Vector3 (0.5f, 0f,-1f);
		Vector3 endPosLeft = new Vector3 (-0.5f, 0f,-1f);

		Vector3 startPosRight = new Vector3 (1.5f, 0f, -1f);
		Vector3 endPosRight = new Vector3 (2.5f, 0f, -1f);

		float Perc = currentLerpTime/lerpTime;
		leftDoor.transform.localPosition = Vector3.Lerp(startPosLeft,endPosLeft, Perc);
		rightDoor.transform.localPosition = Vector3.Lerp(startPosRight,endPosRight, Perc);

		// leftDoor.transform.localPosition = new Vector3 (-0.5f, 0f,-1f);

		// rightDoor.transform.localPosition = new Vector3 (2.5f, 0f, -1f);


	}
	void OnTriggerStay (Collider other){
		other.GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
	}

	void OnTriggerExit(Collider other){
		currentLerpTime = Time.deltaTime;
		if (currentLerpTime >= lerpTime) {
			currentLerpTime = lerpTime;
		}

		Vector3 endPosLeft = new Vector3 (0.5f, 0f,-1f);
		Vector3 startPosLeft = new Vector3 (-0.5f, 0f,-1f);

		Vector3 endPosRight = new Vector3 (1.5f, 0f, -1f);
		Vector3 startPosRight = new Vector3 (2.5f, 0f, -1f);

		float Perc = currentLerpTime/lerpTime;
		leftDoor.transform.localPosition = Vector3.Lerp(startPosLeft,endPosLeft, Perc);
		rightDoor.transform.localPosition = Vector3.Lerp(startPosRight,endPosRight, Perc);
	}
}
