using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour {
	public GameObject pauseMenu;
	private bool paused;

	// Handles when the user clicks "Resume"
	void Resume() {
		changeState();
	}

	// Handles when the user clicks "Exit"
	void Exit() {

	}

	private void changeState() {
		Debug.Log("paused is " + paused);
		paused = !paused;
		Debug.Log("paused is " + paused);

		if (paused) {
			// Activate the pause menu
			pauseMenu.SetActive(true);
			// Pause the time
			Time.timeScale = 0;
		}
		else {
			// Deactivate the pause menu
			pauseMenu.SetActive(false);
			// Resume the time
			Time.timeScale = 1;
		}
	}

	void Start() {
		// default state should be inactive
		pauseMenu.SetActive(false);
		paused = false;
	}

	void Update() {
		// Check if escape is pressed
		if (Input.GetKeyDown(KeyCode.Escape)) {
			changeState();
		}
	}
}
