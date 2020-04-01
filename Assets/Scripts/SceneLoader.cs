using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	// Get current scene and load the next one
	// Or main menu if at the end scene
	public void LoadNextScene() {
		if ((SceneManager.GetActiveScene().buildIndex + 1) <= 2) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		else {
			SceneManager.LoadScene((int)SceneID.MainMenu);
		}
	}

	public void LoadFirstLevel() {
		
	}

	public void ExitToDesktop(){
		Application.Quit();
	}
}
