using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {

    public float enemyHealth;
    public float enemyAttack;

	public float xVelocity;
	public float yVelocity;

    Rigidbody2D r2d;


	private DateTime lastDecision;
    private Animator animator;

	// Use this for initialization
    void Start () {
		lastDecision = DateTime.Now;
        this.r2d = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
    void FixedUpdate () {
        horizontalMove();
	}

    void horizontalMove() {
		r2d.velocity = new Vector3 (xVelocity, yVelocity, 0);
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		//print ("collided with " + coll.gameObject.tag);

		if ((DateTime.Now - lastDecision).TotalMilliseconds < 100) {
			print ("forget about it ...: " + (DateTime.Now - lastDecision).TotalMilliseconds);
			return;
		}

		lastDecision = DateTime.Now;
		if (coll.gameObject.tag == "Wall") {
			xVelocity *= -1;
			yVelocity *= -1;
            animator.SetTrigger("Swap");
        }

        if (coll.gameObject.tag == "Player") {
			coll.gameObject.SendMessage("EnemyHit", enemyAttack);
			coll.gameObject.SendMessage("PlayerDeath");
		}

		

	}

	public void PlayerHit(float attackDamage) {
		enemyHealth -= attackDamage;
		print ("Enemy Health = " + enemyHealth);
	}




}
