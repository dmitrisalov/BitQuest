using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // Constants
    public const int USE_DEFENSE = 1;
    public const int NO_FLAGS = 0;

	public GameObject sprite;
	public int maxHealth;
	public int currentHealth;
	public int defense;
    public GameObject[] equippedItems;

    private Animator animator;
    private bool immune;
    private bool playerDead;

	void KillPlayer() {
		// Do some stuff here
		Debug.Log("Player has died.");
		animator.SetBool("IsDead", true);
        playerDead = true;

		// Disable movement
		PlayerMovement movementScript = GetComponent<PlayerMovement>();
		movementScript.movementEnabled = false;
	}

    private void FlashEquippedItems() {
        foreach (GameObject obj in equippedItems) {
            StartCoroutine(Effects.FlashSprite(obj));
        }
    }

	public void DamagePlayer(int amount, int flag) {
        if (!immune && !playerDead) {
            Debug.Log("Player took " + amount + " damage.");

            int trueDamage = amount;

            if (flag == USE_DEFENSE) {
                // Calculate the actual damage taken, given a defense level
                trueDamage = amount - defense;
                if (trueDamage < 0) {
                    trueDamage = 0;
                }
            }

            // Subtract the damage from the players health
            currentHealth -= trueDamage;

            FlashEquippedItems();

            if (currentHealth <= 0) {
                KillPlayer();
            }

            // Cause player to become immune for a bit
            immune = true;
            Invoke("ResetImmunity", 1f);
        }
	}

    private void ResetImmunity() {
        immune = false;
    }

	// Use this for initialization
	void Start () {
		animator = sprite.GetComponent<Animator>();
		animator.SetBool("IsDead", false);
        currentHealth = maxHealth;
        ResetImmunity();
        playerDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Debugging
		if (Input.GetKeyDown(KeyCode.P)) {
			DamagePlayer(3, NO_FLAGS);
		}
	}
}
