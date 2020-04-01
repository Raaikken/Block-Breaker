using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	// Variables
	[SerializeField] GameObject paddlePos;

	// Internal Variables
	[SerializeField] float paddlePosDiff;
	bool isBallLaunched = false;

	// Debug


	// Start is called before the first frame update
	void Start() {
		paddlePosDiff = transform.position.y - paddlePos.transform.position.y;
	}

	// Update is called once per frame
	void Update() {
		if(!isBallLaunched) {
			LaunchOnClick();
			LockBallToPaddle();
		}
	}

	void LockBallToPaddle() {
		transform.position = new Vector2(paddlePos.transform.position.x, paddlePos.transform.position.y + paddlePosDiff);
	}

	void LaunchOnClick() {
		if(Input.GetMouseButtonDown(0)) {
			isBallLaunched = true;
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15);
		}
	}
}
