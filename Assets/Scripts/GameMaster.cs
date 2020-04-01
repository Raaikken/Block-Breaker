using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour {
	[Range(0.1f, 5f)][SerializeField] float timeSpeed = 1f;
	SceneLoader sceneLoader = null;
	List<GameObject> blocks = new List<GameObject>();
	int blockCount;
	int currentScore = 0;
	[SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] TextMeshProUGUI blocksText;

	// Start is called before the first frame update
	void Start() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;

		blocks.AddRange(GameObject.FindGameObjectsWithTag("Block"));
		sceneLoader = GameObject.FindObjectOfType<SceneLoader>();

		scoreText.text = "Score: " + currentScore.ToString();
		blocksText.text = "Blocks Left: " + blocks.Count.ToString();
	}

	// Update is called once per frame
	void Update() {
		Time.timeScale = timeSpeed;
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

	public void OnBlockDestroy(GameObject block, int points){
		currentScore += points;
		blocks.Remove(block);
		scoreText.text = "Score: " + currentScore.ToString();
		blocksText.text = "Blocks Left: " + blocks.Count.ToString();
	}
}
