using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public float distance = 2;
	public float speed = 1f;
	public AudioSource sourceFX;

	private Vector3 startPos;
	private Vector3 endPos;

	private Vector3 groundToTop;
	private Vector3 topToGround;

	// Use this for initialization
	void Start () {

		startPos = transform.position;
		groundToTop = new Vector3(0, distance, 0);
		topToGround = new Vector3 (0, -distance, 0);

	}

	// Update is called once per frame
	void Update () {

	}

	public void DoorOpen(){

		sourceFX.Play();
		StartCoroutine(Animate(groundToTop));
	}

	public void DoorClose(){
	
		sourceFX.Play();
		StartCoroutine(Animate(topToGround));
	
	}

	////////////////////////////
	// Die Animation des Cubes von unten nach oben, der Vektor fromTo gibt an, wo die Animation anfängt/ wo sie aufhört
	IEnumerator Animate(Vector3 fromTo)
	{
		// Timer wird auf Null gesetzt und die Startposition und Endposition des Cubes wird ermittelt
		float timeSinceStarted = 0f;
		startPos = transform.position;
		endPos = transform.position + fromTo;

		// Der Timer wird gestartet
		while (timeSinceStarted <= 1f)
		{

			// Solange der Timer nicht zuende ist, ist der Cube "beschäftigt" und kann erstmal nicht weiter betätigt werden. Die Positionen vom Cube für die Animation werden berechnet und umgesetzt 
			timeSinceStarted += Time.deltaTime * speed;
			transform.position = Vector3.Lerp(startPos, endPos, timeSinceStarted);
			yield return null;

		}
		// Nachdem der Timer zuende ist, ist der Cube wieder interagierbar und die Kollision ist deaktiviert
		yield return new WaitForSeconds(0.1f);
	}
}