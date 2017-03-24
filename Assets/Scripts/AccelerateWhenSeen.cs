using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateWhenSeen : MonoBehaviour
{
	void Update ()
	{
	  Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
	  bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

	  if (onScreen)
	  {
	    GetComponent<MoveToTargetController>().setTarget(Camera.main.gameObject);
	  }
	}
}
