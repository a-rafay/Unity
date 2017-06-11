using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public static bool incrementNow = false;

	static int newScore;
	static int oldScore;

	void Start() {
		newScore = Brick.score;
		oldScore = newScore;
	}

	// Update is called once per frame
	void Update () {
		if (incrementNow) {
			newScore = Brick.score;
			incrementNow = false;
		}

		if (oldScore <= newScore) {
			this.GetComponent<Text> ().text = oldScore.ToString ();
			oldScore++;
		}
	}
}
