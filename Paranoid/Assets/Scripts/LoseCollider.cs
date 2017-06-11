using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelManager;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		//Debug.Log ("Collision (type: trigger) detected");
	}
	void OnCollisionEnter2D(Collision2D collision) {
		//Debug.Log ("Collision (type: collision) detected");
		Brick.score = 0;
		levelManager.LoadLevel ("Lose");
	}
}
