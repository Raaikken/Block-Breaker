using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour {
	private void Start() {
		Destroy(gameObject, 2f);
	}
}
