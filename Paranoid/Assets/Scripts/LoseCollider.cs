using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelManager;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		// TODO
	}
	void OnCollisionEnter2D(Collision2D collision) {
		Brick.score = 0;
		levelManager.LoadLevel ("Lose");
	}
}
