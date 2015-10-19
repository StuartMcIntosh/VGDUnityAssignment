using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	float timer;
	bool spriteVisible;

	public float attackRate = 0.5f;
	public float attackAnimationVisible = 0.3f;
	public float attackDamage = .2f;

	List<Enemy> enemiesInRange;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		enemiesInRange = new List<Enemy>(0);
		                                    
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			var enemy = other.gameObject.GetComponent<Enemy>();
			if (enemiesInRange.IndexOf(enemy) == -1) {
				print ("Enemy in range ...");
				enemiesInRange.Add(enemy);

			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			print ("Enemy out of range ...");
			enemiesInRange.Remove(other.gameObject.GetComponent<Enemy>());
		}
	}

	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (Input.GetKey("space") && timer > attackRate) {
			spriteVisible = true;
			spriteRenderer.enabled = true;
			timer = 0f;

			for (var i=enemiesInRange.Count - 1; i >= 0; i--) {
				var enemy = enemiesInRange[i];

				enemy.PlayerHit(attackDamage);
				print ("Attacking enemy with: " + attackDamage);

				if (enemy.enemyHealth < float.Epsilon) {
					enemiesInRange.Remove(enemy);
					Destroy (enemy.gameObject);
 
                } 

			}
		}

		if (spriteVisible && timer > attackAnimationVisible) {
			spriteRenderer.enabled = false;
			spriteVisible = false;
		}
	}
}