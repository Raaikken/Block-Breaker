using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
	SceneLoader sceneLoader = null;
	List<GameObject> blocks = new List<GameObject>();
	int blockCount;

	// Start is called before the first frame update
	void Start() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;

		blocks.AddRange(GameObject.FindGameObjectsWithTag("Block"));
		sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
	}

	// Update is called once per frame
	void Update() {
		blockCount = blocks.Count;

		if(Input.GetKeyDown(KeyCode.Escape)) {
			Cursor.visible = !Cursor.visible;
		}

		if(blocks.Count <= 0) {
			sceneLoader.LoadNextScene();
		}
	}

	private void OnDestroy() {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void OnBlockDestroy(GameObject block){
		blocks.Remove(block);
	}
}
