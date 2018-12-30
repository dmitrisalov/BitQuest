using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public GameObject sprite;
	public bool movementEnabled = true;
    public float movementSpeed;
    public float jumpStrength;

    private Animator animator;
	private Rigidbody2D player;
	private float trueSpeed;
	private float trueJump;
    private bool movingRight;
	private bool movingLeft;

    /*
     * Knocks back the player for a certain duration and force.
     *
     * duration The length of time for which the force is applied
     * force The force that is applied in the y direction
     * dir The initial direction of the player 
     *
     * Return 0 to suppress compiler errors
     */
    public IEnumerator Knockback(float duration, float force, Vector3 dir) {
        float timer = 0;

        while (timer < duration) {
            timer += Time.deltaTime;

            // Add the knockback direction, maintaining the z position
            Vector3 knockDir = new Vector3(dir.x * -100, dir.y * force, dir.z);
            player.AddForce(knockDir);
        }

        yield return 0;
    }

	private bool IsGrounded() {
		return player.velocity.y < 0.005 && player.velocity.y > -0.005;
	}

	private void HandleMovement() {
		Vector2 movement = new Vector2(0, player.velocity.y);

		if (movementEnabled) {
			if (Input.GetKey(KeyCode.D)) {
				movement.x += trueSpeed;
			}

			if (Input.GetKey(KeyCode.A)) {
				movement.x += -trueSpeed;
			}

			if (Input.GetKeyDown(KeyCode.Space)) {
				// Don't jump unless the player is on the ground
				if (IsGrounded()) {
					movement.y += trueJump;
				}
			}
		}

		player.velocity = movement;
	}

	private void HandleAnimations() {
		movingRight = player.velocity.x > 0;
		movingLeft = player.velocity.x < 0;

		animator.SetBool("IsGrounded", IsGrounded());

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
		HandleMovement();
		HandleAnimations();
	}
}
