﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class restartScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (0);
		}
	}
}
