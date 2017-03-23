using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour {
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	public Transform startMarker;
	public Vector3 endMarker = new Vector3(3.275F, 0.01F, -1.86F);

	void Start() {
		print (transform.position);
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker);
	}
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp (startMarker.position, endMarker, distCovered);
//		transform.Translate (transform.forward  * Time.deltaTime, Space.World);
//		transform.Rotate (transform.right*10, Time.deltaTime, Space.World);

	}
}
