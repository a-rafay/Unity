using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel(string name) {
		Brick.breakableCount = 0;
		if (name == "Start") {
			Brick.score = 0;
		}
		//Debug.Log ("Loading level " + name);
		SceneManager.LoadScene (name);
	}

	public void LoadNextLevel() {
		Brick.breakableCount = 0;
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
