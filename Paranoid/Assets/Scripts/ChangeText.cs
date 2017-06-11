using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour {
	public Text autoPlayButton;
	public Text difficultyButton;
	private const string _EASY = "Difficulty: Easy";
	private const string _MEDIUM = "Difficulty: Medium";
	private const string _HARD = "Difficulty: Hard";
	private const string _OFF = "Auto Play OFF";
	private const string _ON = "Auto Play ON";

	static string dispAutoPlay = _OFF;
	static string dispDifficulty = _EASY;

	void Update () {
		autoPlayButton.text = dispAutoPlay;
		difficultyButton.text = dispDifficulty;
	}

	public void ToggleAutoPlay (bool selection) {
		if (selection) {
			dispAutoPlay = _ON;
			Paddle.autoPlay = true;
		} else {
			dispAutoPlay = _OFF;
			Paddle.autoPlay = false;
		}
		autoPlayButton.text = dispAutoPlay;
	}

	public void ToggleDifficulty (bool selection) {
		if (!Ball.difficultySet) {
			Ball.difficultySet = true;
			Ball.difficulty = new Vector2 (4.0f, 10.0f);
		}
		if (dispDifficulty == _HARD) {
			dispDifficulty = _EASY;
			Ball.difficulty.x = 4.0f;
			Ball.difficulty.y = 10.0f;
		} else if (dispDifficulty == _EASY) {
			dispDifficulty = _MEDIUM;
			Ball.difficulty.x = 6.0f;
			Ball.difficulty.y = 12.0f;
		} else if (dispDifficulty == _MEDIUM) {
			dispDifficulty = _HARD;
			Ball.difficulty.x = 8.0f;
			Ball.difficulty.y = 15.0f;
		}
		difficultyButton.text = dispDifficulty;
	}
}
