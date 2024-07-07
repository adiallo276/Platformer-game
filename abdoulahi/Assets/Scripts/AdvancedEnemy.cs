/*Created: Sprint 6
 * Last edited: Sprint 7
 * Purpose: Controls the movement of the advanced enemy and makes it follow the main player. It is also in charge of sending the message to kill the player when it collides with them.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvancedEnemy : MonoBehaviour {
	GameObject Character;
	public Transform objectToFollow;

	// Use this for initialization
	void Start () {
		Character = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update (){
	}
		
	private void OnTriggerStay2D(Collider2D other){//Ran when something stays in the advanced enemy's box collider
		if (other.gameObject.tag == "Player") {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(objectToFollow.position.x, 0,0),0.1f);
		}

	}
	private void OnCollisionEnter2D(Collision2D other){//Managers what happens when it collides with the player
		if (SceneManager.GetActiveScene ().name == "Level 3") {
			if (other.gameObject.tag == "Player") {
				Debug.Log ("Killed!");
				Character.SendMessage ("Killed");
			}
		}
	}
			
}
