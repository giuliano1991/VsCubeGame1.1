using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour {

	public float value = 0;
	public GameObject prefab;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col)
	{

		prefab.GetComponent<Rigidbody> ().angularDrag = value;

	}
}
