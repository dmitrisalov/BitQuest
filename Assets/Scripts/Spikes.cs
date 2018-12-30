using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    public GameObject player;
    public int damageAmount;

    private Player playerScript;
    private PlayerMovement movementScript;
    private bool playerColliding;

	// Use this for initialization
	void Start () {
		playerScript = player.GetComponent<Player>();
        movementScript = player.GetComponent<PlayerMovement>();
	}
	
    // Called when the player steps on the 
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            playerColliding = true;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            playerColliding = false;
        }
    }

    void Update() {
        if (playerColliding) {
            playerScript.DamagePlayer(damageAmount, Player.NO_FLAGS);
        }
    }
}
