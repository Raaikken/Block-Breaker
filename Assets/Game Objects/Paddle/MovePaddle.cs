using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour {
	// Variables

	// Internal Variables
	Vector2 mousePos;
	float clampValue;

	// Debug


	// Start is called before the first frame update
	void Start() {
		mousePos = new Vector2();
		clampValue = Camera.main.orthographicSize + 1;
	}

	// Update is called once per frame
	void Update() {
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.x = Mathf.Clamp(mousePos.x, -clampValue, clampValue);
		transform.position = new Vector3(mousePos.x, 0, 0);
	}
}
