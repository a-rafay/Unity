using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public static int score = 0;
	public static int breakableCount = 0;
	public static GameObject poing;

	public Sprite [] hitSprites;
	public int timesHit;
	public GameObject dust;

	private LevelManager levelManager;
	private int maxHits;

	// Use this for initialization
	void Start () {
		poing = GameObject.FindWithTag("poing");
		breakableCount++;
		maxHits = hitSprites.Length + 1;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
	}

	void OnCollisionEnter2D (Collision2D collision) {
		poing.GetComponent<AudioSource>().Play ();
		timesHit++;

		Score.incrementNow = true;
		score += 10;

		if (timesHit >= maxHits) {
			Destroy (gameObject);
			Instantiate (dust, transform.position, Quaternion.identity);
			breakableCount--;
		} else {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
		}
		if (GameObject.FindObjectsOfType<Brick> ().Length == 0) {
			levelManager.LoadNextLevel();
		}
		if (breakableCount == 0) {
			levelManager.LoadNextLevel();
		}
	}

	void OnCollisionExit2D (Collision2D collision) {
		// TODO
	}
}
