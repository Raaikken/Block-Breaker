using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	// Variables
	[SerializeField] int blockMaxHealth = 2;
	[SerializeField] GameMaster gameMaster = null;
	int blockHealth = 0;
	int pointsForDestroyed = 10;
	SpriteRenderer sprite;
	[SerializeField] AudioClip breakSound;

	private void Start() {
		sprite = GetComponent<SpriteRenderer>();
		blockHealth = blockMaxHealth;
		gameMaster = GameObject.FindObjectOfType<GameMaster>();
	}

	private void OnCollisionEnter2D(Collision2D other) {
		blockHealth--;

		if(blockHealth <= 0) {
			AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
			gameMaster.OnBlockDestroy(gameObject, pointsForDestroyed);
			Destroy(gameObject);
		}
	}
}
