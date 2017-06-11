using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public static bool gameIsPaused = false;
	public static bool difficultySet = false;
	public static Vector2 difficulty;
	public static Vector3 gamePausedState;

	static Vector2 gamePausedVelocity;

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool started = false;
	// Use this for initialization
	void Start () {
		gamePausedVelocity = new Vector2(0.0f, 0.0f);
		gamePausedState = new Vector3 (0.0f, 0.0f, 0.0f);
		if (!difficultySet) {
			difficulty = new Vector2 (4.0f, 10.0f);
		}
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) {
			pauseGame ();
		}
		if (gameIsPaused) {
			this.transform.position = gamePausedState;
		} else {
			if (!started) {
				this.transform.position = paddle.transform.position + paddleToBallVector;
				if (Input.GetMouseButtonDown (0) || Input.GetKey (KeyCode.Space)) {
					started = true;
					this.GetComponent<Rigidbody2D> ().velocity = difficulty;
				}
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (!gameIsPaused) {
			Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
			this.GetComponent<Rigidbody2D> ().velocity += tweak;
		}
	}

	public void pauseGame () {
		if (gameIsPaused) {
			this.GetComponent<Rigidbody2D> ().velocity = gamePausedVelocity;
			Paddle.fsmStatesIndex = 0;
		} else {
			gamePausedVelocity = this.GetComponent<Rigidbody2D> ().velocity;
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 0.0f);
			gamePausedState = this.transform.position;
		}
		gameIsPaused = !gameIsPaused;
	}
}
