using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLeft : MonoBehaviour {

	public float distance = 2;
	public int position = 0;
	public float speed = 1f;
	private Vector3 startPos;
	private Vector3 endPos;

	private Vector3 frontToBack;
	private Vector3 backToFront;
	private Vector3 leftToRight;
	private Vector3 rightToLeft;

	// Use this for initialization
	void Start () {

		startPos = transform.position;
		frontToBack = new Vector3(0, 0, -distance);
		backToFront = new Vector3(0, 0, distance);
		leftToRight = new Vector3(distance, 0, 0);
		rightToLeft = new Vector3(-distance, 0, 0);

	}

	// Update is called once per frame
	void Update () {

	}

	public void DoorOpen(){

		switch (position)
		{
		case 0: // FrontToBack
			StartCoroutine(Animate(backToFront));
			break;

		case 1: // BackToFront
			StartCoroutine(Animate(frontToBack));
			break;

		case 2: // LeftToRight
			StartCoroutine(Animate(rightToLeft));
			break;

		case 3: // RightToLeft
			StartCoroutine(Animate(leftToRight));
			break;
		}
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
