using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftElevatorDoor : MonoBehaviour {
	public float speed = 0.05F;
	private Vector3 MovingDirection = Vector3.back;

	// Update is called once per frame	
	void Update() {		

		gameObject.transform.Translate(MovingDirection * speed); ///Time.smoothDeltaTime
         
	    if(gameObject.transform.position.x > 0.5){
	        MovingDirection = Vector3.back;
	    }else if (gameObject.transform.position.x < -0.5) {
	        MovingDirection = Vector3.forward;			
	    }
    }
	
}