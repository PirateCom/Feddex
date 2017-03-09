using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elevatorLevel : MonoBehaviour {
    void OnMouseUp() {
    	print("spider loaded");
        SceneManager.LoadScene ("elevator", LoadSceneMode.Single);
    }
}