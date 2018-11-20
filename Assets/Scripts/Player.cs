using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public GameObject sprite;
	private Animator animator;

	public int maxHealth = 100;
	public int currentHealth;
	public int defense;

	void KillPlayer() {
		// Do some stuff here
		Debug.Log("Player died.");
		animator.SetBool("IsDead", true);

		// Disable movement
		PlayerMovement movementScript = GetComponent<PlayerMovement>();
		movementScript.movementEnabled = false;
	}

	void DamagePlayer(int amount) {
		// Calculate the actual damage taken
		int trueDamage = amount - defense;
		if (trueDamage < 0) {
			trueDamage = 0;
		}

		// Subtract the damage from the players health
		currentHealth -= trueDamage;
		if (currentHealth <= 0) {
			KillPlayer();
		}
	}

	// Use this for initialization
	void Start () {
		animator = sprite.GetComponent<Animator>();
		animator.SetBool("IsDead", false);
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		// Debugging
		if (Input.GetKeyDown(KeyCode.P)) {
			DamagePlayer(100);
		}
	}
}
