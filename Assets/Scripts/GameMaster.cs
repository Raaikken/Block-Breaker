using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {
	[Range(0.1f, 5f)][SerializeField] float timeSpeed = 1f;
	SceneLoader sceneLoader = null;
	List<Block> blocks = new List<Block>();
	List<Ball> balls = new List<Ball>();
	int blockCount;
	int currentScore = 0;
	[SerializeField] TextMeshProUGUI scoreText = null;
	[SerializeField] TextMeshProUGUI blocksText = null;
	[SerializeField] bool isAutoPlayEnabled = false;

	// On first initialization
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

	// Used for initialization if the object wasn't destroyed on load
	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		if(scene.buildIndex == (int)SceneID.EndScene) {
			transform.GetChild(0).gameObject.SetActive(false);
		} else {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Confined;
		}

		balls.Clear();

		blocks.AddRange(GameObject.FindObjectsOfType<Block>());
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

	public void OnBallDestroyed(Ball ball) {
		balls.Remove(ball);

		if(balls.Count <= 0) {
			sceneLoader.LoadEndScene();
		}
	}

	public void OnBlockDestroy(Block block, int points){
		currentScore += points;
		blocks.Remove(block);
		scoreText.text = "Score: " + currentScore.ToString();
		blocksText.text = "Blocks Left: " + blocks.Count.ToString();

		if(blocks.Count <= 0) {
			sceneLoader.LoadNextScene();
		}
	}

	public void AddNewBall(Ball ball) {
		balls.Add(ball);
	}

	public bool GetIsAutoPlayEnabled() {
		return isAutoPlayEnabled;
	}

	public List<Ball> GetAllBalls() {
		return balls;
	}
}
