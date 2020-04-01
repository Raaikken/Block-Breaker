using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {
	// Variables


	private void OnTriggerEnter2D(Collider2D other) {
		SceneManager.LoadScene((int)SceneID.EndScene);
	}
}
