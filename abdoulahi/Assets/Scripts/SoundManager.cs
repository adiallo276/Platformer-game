/*Created: Sprint 6
 *Last edited: Sprint 7
 *Purpose: Makes sure that each collectible/menu makes the corrects sound
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {
	public AudioClip coin;
	public AudioClip bluegem;
	public AudioClip redgem;
	public AudioClip extralife;
	public AudioClip debuff;
	public AudioClip menu;
	public AudioClip nextlevel;
	public AudioClip dead;
	private AudioSource source;
	bool music = true;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name == "Menu" || SceneManager.GetActiveScene ().name == "Level 2 Menu" || SceneManager.GetActiveScene ().name == "Level 1 Menu" || SceneManager.GetActiveScene ().name == "Level 3 Menu") {
			source.PlayOneShot(menu);
		}
	}

	private void OnTriggerEnter2D(Collider2D other){//Runs when an object triggers the collider
		if (music == true) {
			if (other.gameObject.tag == "BlueGem") {
				source.PlayOneShot (bluegem, 1);
			}
		}
	}
	private void OnCollisionEnter2D(Collision2D other){//Runs when an object enters a collision with something else
		if (music == true) {
			if (other.gameObject.tag == "RedGem") {
				source.PlayOneShot (redgem, 1);
			} else if (other.gameObject.tag == "coin") {
				source.PlayOneShot (coin, 1);
			} else if (other.gameObject.tag == "extraLife") {
				source.PlayOneShot (extralife, 1);
			} else if (other.gameObject.tag == "Debuff" || other.gameObject.tag == "Debuff2" || other.gameObject.tag == "Debuff 3") {
				source.PlayOneShot (debuff, 1);
			} else if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "trap") {
				source.PlayOneShot (dead, 1);
			}
		}
	}

	public void MusicOn(){//Turns the music on
		music = true;
		Debug.Log ("Music turned on");
	}
	public void MusicOff(){//Turns the music off
		music = false;
		Debug.Log ("Music turned off");
	}
}

