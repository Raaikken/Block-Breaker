using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {
	[Range(0.1f, 5f)][SerializeField] float timeSpeed = 1f;
	SceneLoader sceneLoader = null;
	List<GameObject> blocks = new List<GameObject>();
	int blockCount;
	int currentScore = 0;
	[SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] TextMeshProUGUI blocksText;

	void Awake() {
		int gameMasterCount = FindObjectsOfType<GameMaster>().Length;
		if(gameMasterCount > 1) {
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
		else {
			DontDestroyOnLoad(gameObject);
		}
	}

	private void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
		SceneManager.sceneUnloaded += OnSceneUnloaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		if(scene.buildIndex == (int)SceneID.EndScene) {
			gameObject.SetActive(false);
			Destroy(gameObject);
		} else {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Confined;
		}

		blocks.AddRange(GameObject.FindGameObjectsWithTag("Block"));
		sceneLoader = GameObject.FindObjectOfType<SceneLoader>();

		scoreText.text = "Score: " + currentScore.ToString();
		blocksText.text = "Blocks Left: " + blocks.Count.ToString();
	}

	void OnSceneUnloaded(Scene current) {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	private void OnDisable() {
		SceneManager.sceneLoaded -= OnSceneLoaded;
		SceneManager.sceneUnloaded -= OnSceneUnloaded;
	}

	// Update is called once per frame
	void Update() {
		Time.timeScale = timeSpeed;
		blockCount = blocks.Count;

		if(Input.GetKeyDown(KeyCode.Escape)) {
			Cursor.visible = !Cursor.visible;
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

		if(blocks.Count <= 0) {
			sceneLoader.LoadNextScene();
		}
	}
}
