using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	// Global vars
	public GameObject sprite;
	private Animator animator;
	bool movingRight;
	bool movingLeft;

	private Rigidbody2D player;
	public float movementSpeed;
	private float trueSpeed;
	public float jumpStrength;
	private float trueJump;

	private bool isGrounded() {
		return player.velocity.y < 0.005 && player.velocity.y > -0.005;
	}

	private void handleMovement() {
		Vector2 movement = new Vector2(0, player.velocity.y);

		if (Input.GetKey(KeyCode.D)) {
			movement.x += trueSpeed;
		}

		if (Input.GetKey(KeyCode.A)) {
			movement.x += -trueSpeed;
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			// Don't jump unless the player is on the ground
			if (isGrounded()) {
				movement.y += trueJump;
			}
		}

		player.velocity = movement;
	}

	private void handleAnimations() {
		movingRight = player.velocity.x > 0;
		movingLeft = player.velocity.x < 0;

		animator.SetBool("IsGrounded", isGrounded());

		if ((movingRight && movingLeft) || (!movingRight && !movingLeft)) {
			// Player should be stopped
			animator.SetBool("MovingRight", false);
			animator.SetBool("MovingLeft", false);
		}
		else if (movingRight) {
			animator.SetBool("MovingRight", true);
			animator.SetBool("MovingLeft", false);
		}
		else if (movingLeft) {
			animator.SetBool("MovingRight", false);
			animator.SetBool("MovingLeft", true);
		}
	}

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D>();
		animator = sprite.GetComponent<Animator>();

		trueSpeed = movementSpeed * 10 * Time.deltaTime;
		trueJump = jumpStrength * 100 * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		handleMovement();
		handleAnimations();
	}
}
