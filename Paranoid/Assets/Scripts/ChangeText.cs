using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour {
	public Text autoPlayButton;
	public Text difficultyButton;

	static string dispAutoPlay = "Auto Play OFF";
	static string dispDifficulty = "Difficulty: Easy";

	void Update () {
		autoPlayButton.text = dispAutoPlay;
		difficultyButton.text = dispDifficulty;
	}

	public void ToggleAutoPlay (bool selection) {
		if (selection) {
			dispAutoPlay = "Auto Play ON";
			Paddle.autoPlay = true;
		} else {
			dispAutoPlay = "Auto Play OFF";
			Paddle.autoPlay = false;
		}
		autoPlayButton.text = dispAutoPlay;
	}

	public void ToggleDifficulty (bool selection) {
		if (!Ball.difficultySet) {
			Ball.difficultySet = true;
			Ball.difficulty = new Vector2 (4.0f, 10.0f);
		}
		if (dispDifficulty == "Difficulty: Hard") {
			dispDifficulty = "Difficulty: Easy";
			Ball.difficulty.x = 4.0f;
			Ball.difficulty.y = 10.0f;
		} else if (dispDifficulty == "Difficulty: Easy") {
			dispDifficulty = "Difficulty: Medium";
			Ball.difficulty.x = 6.0f;
			Ball.difficulty.y = 12.0f;
		} else if (dispDifficulty == "Difficulty: Medium") {
			dispDifficulty = "Difficulty: Hard";
			Ball.difficulty.x = 8.0f;
			Ball.difficulty.y = 15.0f;
		}
		difficultyButton.text = dispDifficulty;
	}
}
