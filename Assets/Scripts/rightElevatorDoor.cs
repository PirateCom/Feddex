using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightElevatorDoor : MonoBehaviour {
	

	public float speed = 0.05F;
	private Vector3 MovingDirection = Vector3.forward;

	// Update is called once per frame	
	void Update() {		
		

		gameObject.transform.Translate(MovingDirection * speed); ///Time.smoothDeltaTime
         
	    if(gameObject.transform.position.x < 1.5){
	        MovingDirection = Vector3.forward;			
	    }else if (gameObject.transform.position.x > 2.5) {
	        MovingDirection = Vector3.back;			
	    }
    }
	
}