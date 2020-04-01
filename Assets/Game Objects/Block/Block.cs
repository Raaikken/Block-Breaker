using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	// Variables
	[SerializeField] bool isUnbreakable = false;
	[SerializeField] int blockMaxHealth = 2;
	[SerializeField] GameMaster gameMaster = null;
	int blockHealth = 0;
	int pointsForDestroyed = 10;
	SpriteRenderer sprite;
	[SerializeField] AudioClip breakSound = null;
	[SerializeField] GameObject visualEffect = null;
	[SerializeField] Sprite[] hitSprites = null;

	private void Start() {
		sprite = GetComponent<SpriteRenderer>();
		blockHealth = blockMaxHealth;
		gameMaster = GameObject.FindObjectOfType<GameMaster>();
		GetComponent<SpriteRenderer>().sprite = hitSprites[blockHealth - 1];
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(isUnbreakable) {
			return;
		}
		blockHealth--;

		if(blockHealth <= 0) {
			AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
			gameMaster.OnBlockDestroy(this, pointsForDestroyed);
			TriggerVFX();
			Destroy(gameObject);
		}
		else {
			GetComponent<SpriteRenderer>().sprite = hitSprites[blockHealth - 1];
		}
	}

	void TriggerVFX() {
		GameObject visuals = Instantiate(visualEffect, transform.position, transform.rotation);
		Destroy(visuals, 1f);
	}

	public bool GetIsUnbreakable() {
		return isUnbreakable;
	}
}
