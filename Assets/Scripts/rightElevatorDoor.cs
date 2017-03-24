using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightElevatorDoor : MonoBehaviour {
	public float rightX = 2.5F;
	public float rightY = 0F;
	public float rightZ = -1F;
	//private Vector3 MovingDirection = Vector3.back;
	//public Vector3 pos;


	void OnMouseUp ()
	{
		transform.localPosition = new Vector3 (rightX, rightY, rightZ);
	}
}