/* Created: Sprint 3;
 * Last edited: Sprint 3;
 * Purpose: Controls the buttons on the menu and directs the player to the correct level.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//What happens when you click the first button
	public void ClickedButtonA(){
		Debug.Log ("Tutorial clicked!");
		SceneManager.LoadScene ("Controls");
	}

	//WHat happens when you click the second button
	public void ClickedButtonB(){
		Debug.Log ("Level 1 Clicked!");
		SceneManager.LoadScene ("Level 1");
	}
	//What happens when you click the third button
		public void ClickedButtonC(){
		Debug.Log ("Settings clicked!");
		SceneManager.LoadScene ("Settings");
	}
}
