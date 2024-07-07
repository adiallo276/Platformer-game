/*Created: Sprint 4
 *Last edited: Sprint 6
 *Purpose: Controlos the enemy movement and what happens when it collides with the player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour {
	string direction;
	float movementSpeed;
	GameObject Character;

	// Use this for initialization
	void Start () {
		direction = "right";
		Character = GameObject.FindGameObjectWithTag ("Player");
		if (SceneManager.GetActiveScene ().name == "Tutorial level") {
			movementSpeed = 2;
		} else if (SceneManager.GetActiveScene ().name == "Level 1") {
			movementSpeed = 4;
		} else if (SceneManager.GetActiveScene ().name == "Level 2") {
			movementSpeed = 6;
		} else {
			movementSpeed = 8;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (direction == "right") {//This if statement 
			transform.Translate (Vector3.right * Time.deltaTime * movementSpeed);
		} else if (direction == "left") {
			transform.Translate (Vector3.left * Time.deltaTime * movementSpeed);
		}
	}

	private void OnTriggerEnter2D(Collider2D other){//Manages what happens when the enemy collides with the markers
	

		if(other.gameObject.tag =="leftMarker"){//This if statement manages what happens if the tag is a leftMarker
			direction = "left";
		}
		else if(other.gameObject.tag == "rightMarker"){//This if statement manages what happens if the tag is a rightMarker
			direction = "right";
		}

		if (other.gameObject.tag == "Player") {//This if statement manages what happens if the tag is a player
			Character.SendMessage ("resetPosition");
		}
}
	}
