using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spiderLevel : MonoBehaviour {
	void OnMouseUp() {
    	print("spider loaded");
        SceneManager.LoadScene ("spider", LoadSceneMode.Single);
    }
}
