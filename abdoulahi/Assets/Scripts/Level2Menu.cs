/*Created: Sprint 5
 *Last edited: Sprint 5
 *Purpose: Controls what happens when you click a button on this scene
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ClickedButtonG(){//What happens when you click the first button
		Debug.Log("Level 2 Clicked!");
		SceneManager.LoadScene("Level 2");
	}
		public void ClickedButtonH(){//What happens when you click the second butto
		Debug.Log("Level 1 Clicked");
		SceneManager.LoadScene("Level 1");
	}
		public void ClickedButtonI(){//What happens when you click the third button
		Debug.Log("Main Menu clicked!");
		SceneManager.LoadScene("Menu");
	}

}
