using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour {
	// Variables
	public bool isPaddleFrozen = false;

	// Internal Variables
	float mousePos;
	float clampValue;
	[SerializeField] float screenUnitWidth;

	// Debug


	// Start is called before the first frame update
	void Start() {
		clampValue = Camera.main.orthographicSize + 1;
	}

	// Update is called once per frame
	void Update() {
		if(!isPaddleFrozen) {
			mousePos = (Input.mousePosition.x / Screen.width) * screenUnitWidth;
			mousePos = Mathf.Clamp(mousePos, 1, screenUnitWidth - 1);
			transform.position = new Vector2(mousePos, transform.position.y);
		}
	}
}
