using UnityEngine;
using System.Collections;
using System;

public class Paddle : MonoBehaviour {
	int X_BLOCKS = 16;
	public static bool autoPlay = true;
	public static int fsmStatesIndex = 0;

	float mouseLastPos;
	private Ball ball;
	private KeyCode[] fsmStates = {KeyCode.S, KeyCode.A, KeyCode.V, KeyCode.E};
	private KeyCode thisKeyPressed;

	// Use this for initialization
	void Start () {
		mouseLastPos = Input.mousePosition.x;
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!Ball.gameIsPaused || hackFSM ()) {
			float yPos = this.transform.position.y;
			float zPos = this.transform.position.z;
			if (autoPlay) {
				AutoPlay (yPos, zPos);
			} else {
				float delta = Input.mousePosition.x - mouseLastPos;

				// Updating the paddle for mouse movement
				if (delta != 0.0f) {
					mouseLastPos = Input.mousePosition.x;
					updatePaddle (Input.mousePosition.x / Screen.width * X_BLOCKS, yPos, zPos);
				}

				// Updatind the paddle for keyboard movement
				bool rightKeyPressed = Input.GetKey (KeyCode.RightArrow);
				bool leftKeyPressed = Input.GetKey (KeyCode.LeftArrow);
				if (rightKeyPressed) {
					updatePaddle (this.transform.position.x + 0.25f, yPos, zPos);
				}
				if (leftKeyPressed) {
					updatePaddle (this.transform.position.x - 0.25f, yPos, zPos);
				}
			}
		}
	}

	void updatePaddle (float xPos, float yPos, float zPos) {
		Vector3 paddleSize = GetComponent<Renderer>().bounds.size;
		xPos = Mathf.Clamp (xPos, (paddleSize.x / 2) * 1.0f, (X_BLOCKS - paddleSize.x / 2) * 1.0f);
		this.transform.position = new Vector3 (xPos, yPos, zPos);
	}

	void AutoPlay (float yPos, float zPos) {
		updatePaddle (ball.transform.position.x, yPos, zPos);
	}

	bool hackFSM () {
		if (!Ball.gameIsPaused) {
			return false;
		} else {
			if (fsmStatesIndex == fsmStates.Length) {
				return true;
			}
			if (Input.anyKey) {
				string keyPressed = Input.inputString.ToUpper ();
				try {
					thisKeyPressed = (KeyCode)(System.Enum.Parse (typeof(KeyCode), keyPressed));
				} catch (Exception e) {}
				if (thisKeyPressed != fsmStates [fsmStatesIndex]) {
					return toState0 ();
				}
			}
			if (Input.GetKeyUp (fsmStates [fsmStatesIndex])) {
				fsmStatesIndex++;
			}
			return false;
		}
	}

	bool toState0 () {
		fsmStatesIndex = 0;
		return false;
	}
}
