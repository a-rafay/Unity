using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public static int score = 0;
	public static int breakableCount = 0;
	public Sprite [] hitSprites;
	public static GameObject poing;
	public int timesHit;
	public GameObject dust;

	private LevelManager levelManager;
	private int maxHits;

	// Use this for initialization
	void Start () {
		poing = GameObject.FindWithTag("poing");
		breakableCount++;
		maxHits = hitSprites.Length + 1;
		//totalBricks = GameObject.FindObjectsOfType<Brick>().Length;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
	}

	void OnCollisionEnter2D (Collision2D collision) {
		poing.GetComponent<AudioSource>().Play ();
		timesHit++;

		Score.incrementNow = true;
		score += 10;
		//print ("hit times: " + timesHit);
		if (timesHit >= maxHits) {
			Destroy (gameObject);
			Instantiate (dust, transform.position, Quaternion.identity);
			breakableCount--;
			//print ("Bricks remaining: " + breakableCount);
		} else {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
		}
		//print ("Total bricks: " + totalBricks);
		if (GameObject.FindObjectsOfType<Brick> ().Length == 0) {
			levelManager.LoadNextLevel();
		}
		//Debug.Log ("Remaining breakable bricks: " + breakableCount);
		if (breakableCount == 0) {
			levelManager.LoadNextLevel();
		}
	}

	void OnCollisionExit2D (Collision2D collision) {

	}
}
