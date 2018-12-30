using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour {
	public GameObject pauseMenu;
    public GameObject hud;
	private bool paused;

	// Handles when the user clicks "Resume"
	public void Resume() {
		changeState();
	}

	// Handles when the user clicks "Exit"
	public void Exit() {
		Application.Quit();
	}

	private void changeState() {
		paused = !paused;

		if (paused) {
			// Activate the pause menu
			pauseMenu.SetActive(true);
            hud.SetActive(false);
			// Pause the time
			Time.timeScale = 0;
		}
		else {
			// Deactivate the pause menu
			pauseMenu.SetActive(false);
            hud.SetActive(true);
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
