using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenAndClose : MonoBehaviour {

	public Door _DoorClose;
	public Door _DoorOpen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {

		_DoorOpen.DoorOpen ();
		_DoorClose.DoorClose ();

	}
}
