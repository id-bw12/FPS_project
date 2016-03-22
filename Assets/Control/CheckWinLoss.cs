﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CheckWinLoss : MonoBehaviour {

	private int playerHealth;
	private GameObject player;
	private Control control;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		control = this.gameObject.GetComponent<Control> ();
	}
	
	// Update is called once per frame
	void Update () {

		PlayerCharacter playerScript = player.GetComponent<PlayerCharacter> ();

		playerHealth = playerScript.GetPlayerHealth();

		if (this.playerHealth == 0 && Time.timeScale == 1) {
			
			Time.timeScale = 0;

			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

			GameOverScreen ("Game Over");

			Application.Quit ();
		} else 
			if (control.getWinCondition () && Time.timeScale == 1) {
				Time.timeScale = 0;

				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;

				GameOverScreen ("You win. Would you like to play again.");
		}

	
	}

	private void GameOverScreen(string message){

		UIMakerScript menuMaker = new UIMakerScript ();

		GameObject canvas = menuMaker.CreateCanvas(this.transform);

		menuMaker.CreateEventSystem(canvas.transform);

		GameObject panel = menuMaker.CreatePanel(canvas.transform);

		menuMaker.CreateText(panel.transform, new Vector2(-20, 50), new Vector2(160, 50), "headerText",message, 14);

		menuMaker.CreateButton(panel.transform, new Vector2(0, -10), new Vector2(160, 25), "restartButton","Yes", delegate{ResetScene();});
    }

    private void ResetScene() {
        
        SceneManager.LoadScene("Maze");

    }
}
