using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour {

	public GameObject spawnLocation;
	private Vector3 location;
	bool firstSpawn = true;

	// Audio
	public AudioClip[] clipFX;
	public AudioSource sourceFX;

	// Use this for initialization
	void Start () {

		GetComponent<Renderer> ().enabled = false;
		GetComponent<Rigidbody> ().isKinematic = true;
		location = spawnLocation.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	public void Spawn() {

		if (firstSpawn == true) {

			GetComponent<Renderer> ().enabled = true;
			GetComponent<Rigidbody> ().isKinematic = false;
			firstSpawn = false;


		} else {

			GetComponent<Rigidbody>().angularDrag = 0.1f;
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			transform.position = location;

		}
	}

	void OnCollisionEnter(Collision col) {

		if (col.relativeVelocity.magnitude > 2.3f)
		{
			PlaySoundFX (Random.Range (0, 20));
		}
	}

	void PlaySoundFX (int clip)
	{

		sourceFX.clip = clipFX [clip];
		sourceFX.Play();

	}
}
