using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

	public Door _Door;
	public GameObject prefab;
	public AudioSource sourceFX;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.name == "Sphere") {
			_Door.DoorOpen ();
			Destroy (prefab);
			sourceFX.Play ();
		}

	}

	/*void OnCollisionEnter (Collision col) {
	
		if (col.gameObject.name == "Sphere") 
		{
			
		_Door.DoorOpen ();
		Destroy (prefab);
		sourceFX.Play();

		}

	}*/
}
