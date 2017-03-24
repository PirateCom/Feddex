using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayerWhenSeen : MonoBehaviour
{
  public float Delay = 2.0f;
  private float _startTime;

  void Start()
  {
    _startTime = Time.time;
  }

	void Update ()
	{
	  Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
	  bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

	  if (onScreen && Time.time > _startTime + Delay)
	  {
	    GetComponent<MoveToTargetController>().setTarget(Camera.main.gameObject);
	  }
	}
}
