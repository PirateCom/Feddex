using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public float rotateSpeed = 25F;
	public float speed = 1F;
	private Vector3 MovingDirection = Vector3.up;

	// Update is called once per frame	
	void Update() {		
		transform.Rotate(Vector3.up * (Time.deltaTime * rotateSpeed ), Space.World);

		gameObject.transform.Translate(MovingDirection * speed); ///Time.smoothDeltaTime
         
	    if(gameObject.transform.position.y > .65){
	        MovingDirection = Vector3.down;
	    }else if (gameObject.transform.position.y < .35) {
	        MovingDirection = Vector3.up;
	    }
    }
}
