/*Created: Sprint 7
 *Last edited: Sprint 7
 *Purpose: Adds a timer to the game and also is in charge of sending a message to kill the player when they reach the time limit
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
	public TextMeshPro timer;
	GameObject Character;
	private Canvas MainCanvas;
	string level;


	// Use this for initialization
	void Start () {
		Character = GameObject.FindGameObjectWithTag ("Player");
		MainCanvas = GameObject.FindObjectOfType<Canvas> ();
		MainCanvas.enabled = false;
		level = SceneManager.GetActiveScene ().name;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			MainCanvas.enabled = true;
		}
		if (level == "Level 2") {
			timer.text = "Time: "+ Time.timeSinceLevelLoad.ToString ("0") + "/180";
			if (Time.timeSinceLevelLoad >= 180) {
				Character.SendMessage ("Killed");
				Debug.Log ("Time ran out!");

			}
		} else if (level == "Level 3") {
			timer.text = "Time: " + Time.timeSinceLevelLoad.ToString ("0") + "/300";
			if (Time.timeSinceLevelLoad >= 300) {
				Character.SendMessage ("Killed");
				Debug.Log ("Time ran out!");
			}
		}
	}
	public void Clicked(){//Ran when the continue playing button is clicked
		MainCanvas.enabled = false;
	}
	public void Exit(){//Ran when the exit button is clicked
		SceneManager.LoadScene ("Menu");
	}

	

}
