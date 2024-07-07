/*Created: Sprint 2
 * Last edited: Sprint 5
 * Purpose: Spawns the player to the next level when they reach the alter
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Alter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnCollisionEnter2D(Collision2D other){//Manages which scene to load when the player reaches the alter
		if (other.gameObject.tag == "Player") {
			if (SceneManager.GetActiveScene ().name == "Tutorial level") {
				SceneManager.LoadScene ("Level 1 Menu");
			} else if (SceneManager.GetActiveScene ().name == "Level 1") {
				SceneManager.LoadScene ("Level 2 Menu");
			} else if (SceneManager.GetActiveScene ().name == "Level 2") {
				SceneManager.LoadScene ("Level 3 Menu");
			}
		}
	}
}
