using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	// Variables
	[SerializeField] GameObject paddle = null;
	[SerializeField] float launchSpeed = 10f;
	[SerializeField] float screenUnitWidth = 16f;
	[SerializeField] float screenUnitHeight = 12f;
	[SerializeField] AudioClip[] ballSounds = null;

	// Internal Variables
	Vector2 mousePos;
	float paddlePosDiff;
	bool isBallLaunched = false;
	bool isAiming = false;
	Vector2 launchDirection;
	[SerializeField] SpriteRenderer aimingArrow = null;
	AudioSource audioSource;

	// Debug


	// Start is called before the first frame update
	void Start() {
		paddlePosDiff = transform.position.y - paddle.transform.position.y;
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update() {
		if(isAiming) {
			mousePos = new Vector2((Input.mousePosition.x / Screen.width) * screenUnitWidth,
								   (Input.mousePosition.y / Screen.height) * screenUnitHeight);
			launchDirection = mousePos - (Vector2)transform.position;
			launchDirection = launchDirection.normalized;
			LaunchOnClick();
		}

		if(!isBallLaunched) {
			LockBallToPaddle();
		}
	}

	void LockBallToPaddle() {
		transform.position = new Vector2(paddle.transform.position.x, paddle.transform.position.y + paddlePosDiff);
		if(Input.GetMouseButton(0)) {
			isAiming = true;
			aimingArrow.enabled = true;
			paddle.GetComponent<MovePaddle>().isPaddleFrozen = true;
		}
	}

	// Freezes paddle to allow mouse to be moved to pick a direction of launch
	// Launches ball to direction picked with mouse movement
	void LaunchOnClick() {
		if(Input.GetMouseButtonDown(0)) {
			paddle.GetComponent<MovePaddle>().isPaddleFrozen = false;
			Vector2 launchVector = launchDirection.normalized * launchSpeed;
			isBallLaunched = true;
			isAiming = false;
			aimingArrow.enabled = false;
			GetComponent<Rigidbody2D>().velocity = launchVector;
			Destroy(aimingArrow.gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(isBallLaunched) {
			AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
			audioSource.PlayOneShot(clip);
		}
	}
}
