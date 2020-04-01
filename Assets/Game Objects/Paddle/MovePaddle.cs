using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour {
	// Variables
	public bool isPaddleFrozen = false;

	// Internal Variables
	float mousePos;
	float clampValue;
	[SerializeField] float screenUnitWidth = 0;
	GameMaster gameMaster;

	// Debug


	// Start is called before the first frame update
	void Start() {
		clampValue = Camera.main.orthographicSize + 1;
		gameMaster = FindObjectOfType<GameMaster>();
	}

	// Update is called once per frame
	void Update() {
		if(!isPaddleFrozen) {
			mousePos = (Input.mousePosition.x / Screen.width) * screenUnitWidth;
			mousePos = Mathf.Clamp(GetXPos(), 1, screenUnitWidth - 1);
			transform.position = new Vector2(mousePos, transform.position.y);
		}
	}

	private float GetXPos() {
		if(gameMaster.GetIsAutoPlayEnabled()) {
			List<Ball> balls = gameMaster.GetAllBalls();
			float closestDistance = 100;
			Ball closestBall = null;
			foreach(Ball ball in balls) {
				float nextDistance = Vector2.Distance(gameObject.transform.position, ball.gameObject.transform.position);
				if(nextDistance < closestDistance) {
					closestBall = ball;
					closestDistance = nextDistance;
				}
			}

			return closestBall.transform.position.x;
		}
		else {
			return mousePos;
		}
	}
}
