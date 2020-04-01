using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	// Variables
	[SerializeField] int blockHealth = 3;

	private void OnCollisionEnter2D(Collision2D other) {
		blockHealth--;

		if(blockHealth <= 0) {
			Destroy(gameObject);
		}
	}
}
