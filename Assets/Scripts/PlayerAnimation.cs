using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
	public GameObject sprite;
	private Animator animator;
	private Rigidbody2D player;
	private bool movingRight;
	private bool movingLeft;

	// Use this for initialization
	void Start () {
		animator = sprite.GetComponent<Animator>();
		player = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		movingRight = player.velocity.x > 0;
		movingLeft = player.velocity.x < 0;

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
}
