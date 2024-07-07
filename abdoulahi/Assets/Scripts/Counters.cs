/* Created: Sprint 2
 * Last edited: Sprint 6
 * Purpose: Counts the number of gems and the number of gems remaining in the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counters : MonoBehaviour {

	public TextMeshPro GemCounter;
	public TextMeshPro LivesCounter;
	GameObject [] totalbluegems; 
	GameObject Character;
	int lives;

	// Use this for initialization
	void Start () {
		Character = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		totalbluegems = GameObject.FindGameObjectsWithTag ("BlueGem");
		GemCounter.text = "Blue Gems remaining: " + totalbluegems.Length.ToString ();

		lives = Character.GetComponent<CharacterMovement> ().lives;
		LivesCounter.text = "Lives remaining: " + lives;
			
		if (totalbluegems.Length ==  0){
			Character.SendMessage("SpawnAlter");
		}
	}
}
