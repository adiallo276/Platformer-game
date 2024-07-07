/* Created: Sprint 2
 * Last edited; Sprint 3
 * Purpose: Controls what will happen to the associated gems when it enters a collision.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {//Manages what happens when the player collides with something

		if (other.gameObject.tag == "Player") {
			Destroy (this.gameObject);
		}
	}
}
