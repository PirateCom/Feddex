using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToMenuScreen : MonoBehaviour {
	void OnMouseUp() {
    	print("spider loaded");
        SceneManager.LoadScene ("menu", LoadSceneMode.Single);
    }
}
