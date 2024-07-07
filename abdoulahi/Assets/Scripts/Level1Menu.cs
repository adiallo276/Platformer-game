/*Created: Sprint 5
 *Last edited: Sprint 5:
 *Purpose: Loads a scene depending on what button you click on.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//What happens when you click the first button
	public void ClickedButtonD(){
		Debug.Log("Level 1 Clicked!");
		SceneManager.LoadScene("Level 1");
	}
		//What happens when you click the second button
		public void ClickedButtonE(){
		Debug.Log("Tutorial Clicked!");
		SceneManager.LoadScene("Tutorial");
	}
		//What happens when you click the third button
		public void ClickedButtonF(){
		Debug.Log("Main Menu clicked!");
		SceneManager.LoadScene("Menu");
	}

}
