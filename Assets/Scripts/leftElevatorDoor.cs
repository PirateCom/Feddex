using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftElevatorDoor : MonoBehaviour {
	public float leftX = -0.5F;
	public float leftY = 0F;
	public float leftZ = -1F;
	//private Vector3 MovingDirection = Vector3.back;
	//public Vector3 pos;


	void OnMouseUp ()
	{
		transform.localPosition = new Vector3 (leftX, leftY, leftZ);
	}
}