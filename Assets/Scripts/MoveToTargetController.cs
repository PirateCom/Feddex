using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetController : MonoBehaviour {
	public float speed = 0.05F;

	private Vector3 waypoint;
	private Vector3 velocity = Vector3.zero;

	public GameObject target;

	void Start () {
		waypoint = target.transform.position;
		waypoint.y = 0.0f;
	}

	void Update () {
//		transform.position += transform.forward * speed;

		if (Vector3.Distance (transform.position, waypoint) < 1) {
			GetComponent<Animator> ().Stop ();	
		} else {
			transform.position += transform.forward * speed;
		}

		if  (Vector3.Angle(transform.forward, waypoint - transform.position) > 2) {
			rotateToTarget ();
		}
	}

	void rotateToTarget() {
		Quaternion targetRotation = Quaternion.LookRotation (waypoint - transform.position);
		float str = Mathf.Min (Time.deltaTime, 1);

		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);
	}
}
