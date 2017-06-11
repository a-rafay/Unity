using UnityEngine;
using System.Collections;

public class MoozikPlayer : MonoBehaviour {
	static bool isMusicRunning = false;

	void Awake () {
		if (isMusicRunning) {
			Destroy (gameObject);
		} else {
			isMusicRunning = true;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}
