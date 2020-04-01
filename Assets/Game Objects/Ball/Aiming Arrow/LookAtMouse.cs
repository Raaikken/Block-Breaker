using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {
	// Components
	Ball ball;
	
	// Start is called before the first frame update
	void Start() {
		ball = gameObject.GetComponentInParent<Ball>();
	}

	// Get launch direction from ball and rotate to point at that direction
	void Update() {
		Vector2 mousePos = new Vector2((Input.mousePosition.x / Screen.width) * 16,
								(Input.mousePosition.y / Screen.height) * 12);
		float AngleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
	}
}
