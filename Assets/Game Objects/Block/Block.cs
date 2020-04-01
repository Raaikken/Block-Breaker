using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	// Variables
	[SerializeField] int blockHealth = 2;
	SpriteRenderer sprite;

	private void Start() {
		sprite = GetComponent<SpriteRenderer>();
	}

	private void OnCollisionEnter2D(Collision2D other) {
		blockHealth--;

		if(blockHealth <= 0) {
			Destroy(gameObject);
		}

		if(blockHealth == 1) {
			sprite.color = Color.red;
		}
	}
}
