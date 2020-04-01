using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
	// Variables
	

	// Internal Variables


	// Debug


	// Start is called before the first frame update
	void Start() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;
	}

	// Update is called once per frame
	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape) && Cursor.lockState == CursorLockMode.Locked) {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.None;
		}

		if(Input.GetKeyDown(KeyCode.Escape) && Cursor.lockState == CursorLockMode.None) {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}
