using UnityEngine;
using System.Collections;

public class LevelReloader : MonoBehaviour {

	//Loads the next level of the game on collision with end point
	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "Player") {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
