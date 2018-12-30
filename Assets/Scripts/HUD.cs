using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    public GameObject player;
    public Sprite[] hearts;

    private GameObject hud;
    private Image healthImage;
    private Player playerScript;
    private int playerHealth;
    private int maxHealth;

	// Use this for initialization
	void Start () {
        hud = gameObject.transform.Find("HUD").gameObject;

        // Find the image component that shows the hearts
		healthImage = hud.transform.Find("Health").
            gameObject.transform.Find("Image").
            gameObject.GetComponent<Image>();

        playerScript = player.transform.GetComponent<Player>();
        maxHealth = playerScript.maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		playerHealth = playerScript.currentHealth;

        if (playerHealth > 0) {
            // Update the hearts image accordingly
            healthImage.sprite = hearts[maxHealth - playerHealth];
        }
        else {
            // Player is dead. Disable the HUD altogether
            hud.SetActive(false);
        }
	}
}
