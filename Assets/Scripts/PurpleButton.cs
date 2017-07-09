using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleButton : MonoBehaviour {

	////////////////////////////
	// Alle Variablen

	public PurpleCube _PurpleCube;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	////////////////////////////
	// Funktion die die Funktion Spawn im anderen Script auslöst
	public void LeftTrigger () {

		_PurpleCube.LeftTriggerRotate();

	}

	public void RightTrigger () {
		
		_PurpleCube.RightTriggerRotate();

	}
}