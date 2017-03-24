using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetController : MonoBehaviour
{
  private Vector3 waypoint;
  private AudioSource source;

  public float speed = 0.05F;
  public GameObject target;

	void Start () {
		setTarget(target);
	}

  void Awake()
  {
    source = GetComponent<AudioSource>();
    source.Play();
  }

	void Update () {
//		transform.position += transform.forward * speed;

		if (Vector3.Distance (transform.position, waypoint) < 5) {
		  Vector3 pointBehind = waypoint - (target.transform.forward * 3f);
		  pointBehind.y = 0.0f;
		  waypoint = pointBehind - (target.transform.right * (Random.Range(0, 10) % 2 == 0 ? -1 : 1));
		  rotateToTarget(5f);
		  transform.position += transform.forward * speed * 2;
		}

	  transform.position += transform.forward * speed;


		if  (Vector3.Angle(transform.forward, waypoint - transform.position) > 2) {
			rotateToTarget ();
		}
	}

  public void setTarget(GameObject tgt)
  {
    target = tgt;
    waypoint = target.transform.position;
    waypoint.y = 0.0f;
  }

	void rotateToTarget(float spd = 1) {
		Quaternion targetRotation = Quaternion.LookRotation (waypoint - transform.position);
		float str = Mathf.Min (spd * Time.deltaTime, 1);

		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);
	}
}
