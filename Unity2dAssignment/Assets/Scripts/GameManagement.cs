using UnityEngine;
using System.Collections;


public class GameManagement : MonoBehaviour {

    LevelManager createLevels;
    public string level;
	// Use this for initialization
	void Start () {
        createLevels = new LevelManager();
        createLevels.LoadWorld(level);
	}
	
	// Update is called once per frame
	void Update () {

    }
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player") {
            createLevels.LoadWorld(level + 1);
        }
    }
}
