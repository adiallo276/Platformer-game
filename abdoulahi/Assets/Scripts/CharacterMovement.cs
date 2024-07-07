/* Created: Sprint 1
 * Last edited: Sprint 7
 * Purpose: Controls the movement and charcterisitics of the main player and also handles how the player reacts to different items.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterMovement : MonoBehaviour {

	float speed;
	Rigidbody2D rb;
	public int lives;
	bool immune;
	bool collect;
	public TextMeshPro buffdebuff;
	public TextMeshPro buffdebuff2;
	public TextMeshPro buffdebuff3;
	public TextMeshPro buffdebuff4;
	public TextMeshPro buffdebuff5;
	public TextMeshPro buffdebuff6;
	bool text;
	float collectedtime;
	float collectedtime2;
	float collectedtime3;
	float collectedtime4;
	float collectedtime5;
	float collectedtime6;
	string text1;
	string text2;
	string text3;
	string text4;
	string text5;
	string text6;
	bool texttrue = false;
	bool texttrue2 = false;
	bool texttrue3 = false;
	bool texttrue4 = false;
	bool texttrue5 = false;
	bool texttrue6 = false;

		
	void Start () {//Happens at the beggining of each scene and sets the lives
		speed = 5.1f;
		rb = GetComponent<Rigidbody2D> ();
		collect = false;
		if (SceneManager.GetActiveScene ().name == "Tutorial level") {
			lives = 10;
		} else if (SceneManager.GetActiveScene ().name == "Level 1") {
			lives = 5;
		} else if (SceneManager.GetActiveScene ().name == "Level 2") {
			lives = 4;
		} else {
			lives = 5;
		}
	 }

		
	void FixedUpdate () {//Updates 30 times a second and manages the key controls
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.A)) {
			transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * speed, 0, 0);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.Space)) {
			rb.AddForce (Vector2.up * 125);
		}
		if (texttrue3 == true) {
				buffdebuff3.text = text3 + " " + (Time.timeSinceLevelLoad - collectedtime3).ToString ("0") + "/40";
		}if (texttrue == true) {
				buffdebuff.text = text1 + " " + (Time.timeSinceLevelLoad - collectedtime).ToString ("0") + "/10";
		}if (texttrue2 == true) {
				buffdebuff2.text = text2 + " " + (Time.timeSinceLevelLoad - collectedtime2).ToString ("0") + "/10";
		}if (texttrue4 == true) {
				buffdebuff4.text = text4 + " " + (Time.timeSinceLevelLoad - collectedtime4).ToString ("0") + "/10";
		}if (texttrue5 == true) {
				buffdebuff5.text = text5 + " " + (Time.timeSinceLevelLoad - collectedtime5).ToString ("0") + "/10";
		}if (texttrue6 == true) {
				buffdebuff6.text = text6 + " " + (Time.timeSinceLevelLoad - collectedtime6).ToString ("0") + "/10";
		}

	}


   private void OnCollisionEnter2D (Collision2D other)
	{//Responsible for dealing with collisions with different collectibles and what will happen
		if (other.gameObject.tag == "Debuff2" && immune == false) {
			collect = true;
			StartCoroutine ("debuff2");
			Debug.Log ("Cannot collect any collectibles!");
			Destroy (other.gameObject);
			collectedtime5 = Time.timeSinceLevelLoad;
			texttrue5 = true;
			text5 = "Cannot collect anything!";
		}
		if (collect == false) {
			if (other.gameObject.tag == "RedGem") {
				immune = true;
				Debug.Log ("Immune for 10 seconds!");
				StartCoroutine ("NotVulnerable");
				Destroy (other.gameObject);
				collectedtime = Time.timeSinceLevelLoad;
				texttrue = true;
				text1 = "Immune!";

			}

			if (other.gameObject.tag == "coin") {
				Debug.Log ("Speed increased for 10 seconds!");
				StartCoroutine ("ExtraSpeed");
				speed = 8f;
				Destroy (other.gameObject);
				collectedtime2 = Time.timeSinceLevelLoad;
				text2 = "Speed increased!";
				texttrue2 = true;
			}

			if (other.gameObject.tag == "extraLife") { 
				StartCoroutine ("Extralives");
				Debug.Log ("Extra lives for 40 seconds!");
				lives = lives + 3;
				collectedtime3 = Time.timeSinceLevelLoad;
				Destroy (other.gameObject);
				text3 = "Extra 3 lives!";
				texttrue3 = true;
			}
		}
		if (other.gameObject.tag == "Debuff" && immune == false) {
			Destroy (other.gameObject);
			Debug.Log ("You have been slowed for 10 seconds!");
			speed = 2f;
			StartCoroutine ("VulnerableDeBuff");
			collectedtime4 = Time.timeSinceLevelLoad;
			text4 = "Slowed down!";
			texttrue4 = true;
		}	

		if (other.gameObject.tag == "Enemy" && immune == false) {
			SendMessage ("resetPosition");
		}
		if (other.gameObject.tag == "Debuff 3" && immune == false) {
			Destroy (other.gameObject);
			StartCoroutine ("Debuff3");
			Debug.Log ("Movement frozen!");
			speed = 0f;
			collectedtime6 = Time.timeSinceLevelLoad;
			text6 = "Movement frozen!";
			texttrue6 = true;
		}
		if (other.gameObject.tag == "trap") {
			Debug.Log ("You have been spiked!");
			SendMessage ("resetPosition");
		}
	}		

	public void setLives (){//Deals with the lives of the player i.e. if the player dies, reduce their lives by 1

		lives -= 1;
		if(lives <= 0){
			Debug.Log("You have died!!");
			SceneManager.LoadScene ("Lost");
		}
	}
	void Killed(){//If the player collides with an advanced enemy or runs out of time it will set the lives to 0
		lives = 0;
		SendMessage ("setLives");

	}

	void resetPosition(){//Deals with how the player respawns and makes sure it respawns in the right place
		if (SceneManager.GetActiveScene ().name == "Level 3") {
			transform.SetPositionAndRotation (new Vector3 (81.67f, 4.17f, 0), Quaternion.identity);
		} else {
			transform.SetPositionAndRotation (new Vector3 (-8.29f, 0.15f, 0), Quaternion.identity);
		}
			SendMessage ("setLives");
	}


	IEnumerator VulnerableDeBuff(){//Gives a timer for the debuff and sets the setting back to normal after that time
		yield return new WaitForSeconds (10f);
		speed = 5.1f;
		Debug.Log ("Speed back to normal!");
		buffdebuff4.text = "";
		texttrue4 = false;

	}

	IEnumerator NotVulnerable(){//Gives a timer for the buff and sets the setting back to normal after that time
		yield return new WaitForSeconds (10f);
		immune = false;
		Debug.Log ("Immunity gone!"); 
		buffdebuff.text = "";
		texttrue = false;
	}

	IEnumerator ExtraSpeed(){//Gives a timer for the buff and sets the setting back to normal after that time
		yield return new WaitForSeconds (10f);
		speed = 5.1f;
		Debug.Log ("Speed back to normal!");
		buffdebuff2.text = "";
		texttrue2 = false;
	}

	IEnumerator debuff2(){//Gives a timer for the debuff and sets the setting back to normal after that time
		yield return new WaitForSeconds (10f);
		collect = false; 
		Debug.Log ("Can collect now!");
		buffdebuff5.text = "";
		texttrue5 = false;
	}

	IEnumerator Debuff3(){//Gives a timer for the debuff and sets the setting back to normal after that time
		yield return new WaitForSeconds (10f);
		Debug.Log ("Can now move!");
		speed = 5f;
		buffdebuff6.text = "";
		texttrue6 = false;
	}

	IEnumerator Extralives(){//Gives a timer for the buff and sets the setting back to normal after that time
		yield return new WaitForSeconds (40f);
		Debug.Log ("Lives back to normal!");
		lives = lives - 3;
		buffdebuff3.text = "";
		texttrue3 = false;
	}
}
