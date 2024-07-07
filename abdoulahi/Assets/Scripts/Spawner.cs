using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spawner : MonoBehaviour {
	public GameObject Alter;
	bool spawned;
	Vector3 SpawnedPosition;
	// Use this for initialization
	void Start () {
		spawned = false;
		if (SceneManager.GetActiveScene ().name == "Tutorial level") {
			SpawnedPosition = new Vector3 (175.1471f, 0.4298122f, 0);
		} else if (SceneManager.GetActiveScene ().name == "Level 1") {
			SpawnedPosition = new Vector3 (157.029f, 1.717f, 0);
		} else if (SceneManager.GetActiveScene ().name == "Level 2") {
			SpawnedPosition = new Vector3 (239.04f, -0.44f, 0);
		} else if (SceneManager.GetActiveScene ().name == "Level 3") {
			SpawnedPosition = new Vector3 (752.2274f, -0.46030f, 0);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
			
		
	}

	void SpawnAlter(){
		if (spawned == false) {
			Instantiate (Alter, SpawnedPosition, Quaternion.identity);
			spawned = true;
			Debug.Log ("Alter spawned");
		}
	}
}
