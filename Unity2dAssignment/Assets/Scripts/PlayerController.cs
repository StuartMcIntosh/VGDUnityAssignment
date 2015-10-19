using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	// Movement Variables

	public float walkSpeed;
	public float playerHealth;
	//public float playerAttack;

	private Animator animator;

	Rigidbody2D r2d;


	void Start() {
		this.r2d = GetComponent<Rigidbody2D> ();
		this.animator = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		movement();

	}

	void movement() {
		if (Input.GetKey ("up")) {
			this.animator.SetTrigger("WalkUp");
			r2d.velocity = new Vector3 (0, walkSpeed, 0);
		}
		else if (Input.GetKey ("down")) {
            this.animator.SetTrigger("WalkDown");
			r2d.velocity = new Vector3 (0, -walkSpeed, 0);
		}
		else if (Input.GetKey ("left")) {
            this.animator.SetTrigger("WalkLeft");
			r2d.velocity = new Vector3 (-walkSpeed, 0, 0);
		}
		else if (Input.GetKey ("right")) {
            this.animator.SetTrigger("WalkRight");
			r2d.velocity = new Vector3 (walkSpeed, 0, 0);
		}
		else {
			r2d.velocity = new Vector3 (0, 0, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Finish") {
			Destroy (gameObject);
			print ("Reached the Finish!");
		}
	}

	void EnemyHit(float attackDamage) {
		playerHealth -= attackDamage;
		print ("Player Health = " + playerHealth);
	}

	void PlayerDeath() {
		if (playerHealth <= 0) {
			Destroy (gameObject);
			print ("Player Died!");
            Application.LoadLevel(Application.loadedLevel);
		}
	}
    void HealthUpgrade() {
        playerHealth += 0.5F;
    }
}