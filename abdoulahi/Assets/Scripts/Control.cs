﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Clicked(){
		SceneManager.LoadScene ("Tutorial level");
	}
	public void Settings(){
		SceneManager.LoadScene ("Menu");
	}
}
