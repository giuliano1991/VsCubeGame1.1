using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-------------------------------------------------------

public class BlueCube : MonoBehaviour {

	////////////////////////////
	// Alle Variablen

	// Öffentlicher Boolean zum Überprüfen ob der Cube oben ist
	public bool upCube = false;

	// Die Geschwindigkeit des Cubes + die die Kraft die ausgeübt auf der Kugel
	public float speed = 1f;
	public float jumpForce = 0f;

	// Startposition, Endposition und Distanz
	private Vector3 startPos;
	private Vector3 endPos;
	private float distance = 1f;

	// Vektoren für From To deklarieren (initialiseren hier oben noch nicht möglich)
	private Vector3 groundToTop;
	private Vector3 topToGround;
	private Vector3 frontToBack;
	private Vector3 backToFront;
	private Vector3 leftToRight;
	private Vector3 rightToLeft;

	// Zugriff auf die anderen Scripte
	CubeLocation _cubeLocation;

	// Audio
	public AudioClip[] clipFX;
	public AudioSource sourceFX;

//-------------------------------------------------------

	////////////////////////////
	// Use this for initialization
	void Start () {

		_cubeLocation = GetComponent<CubeLocation>();

		startPos = transform.position;

		// initialiserie Vektoren
		groundToTop = new Vector3(0, distance, 0);
		topToGround = new Vector3(0, -distance, 0);
		frontToBack = new Vector3(0, 0, -distance);
		backToFront = new Vector3(0, 0, distance);
		leftToRight = new Vector3(distance, 0, 0);
		rightToLeft = new Vector3(-distance, 0, 0);

	}

//-------------------------------------------------------

	////////////////////////////
	// Update is called once per frame
	void Update () {

	}

//-------------------------------------------------------

//////////////////////////////////////////////////////////////////////////////////////////
// ==============
// GAMEPLAY FUNKTIONEN
// ==============
//{///////////////////////////////////////////////////////////////////////////////////////

//-------------------------------------------------------

	////////////////////////////
	// Die Funktion wenn die rechte oder linke Maustaste gedrückt wird
	public void BlueCubeTrigger () {

		// Wird geprüft ob der Cube oben ist sprich schon einmal aktiviert wurde
		if (upCube != false & _cubeLocation.isBusy != true) {

			// Switchabfrage für die Position des Cubes + die korrekte Berechnung der neuen Position
			switch (_cubeLocation.location)
			{
			case 0: // TopToGround
				PlaySoundFX (1);
				StartCoroutine(Animate(topToGround));
				break;

			case 1: // GroundToTop
				PlaySoundFX (1);
				StartCoroutine(Animate(groundToTop));
				break;

			case 2: // BackToFront
				PlaySoundFX (1);
				StartCoroutine(Animate(backToFront));
				break;

			case 3: // FrontToBack
				PlaySoundFX (1);
				StartCoroutine(Animate(frontToBack));
				break;

			case 4: // RightToLeft
				PlaySoundFX (1);
				StartCoroutine(Animate(rightToLeft));
				break;

			case 5: // LeftToRight
				PlaySoundFX (1);
				StartCoroutine(Animate(leftToRight));
				break;
			}

			upCube = false;

		}
	}
	
//-------------------------------------------------------

//} ENDE GAMEPLAY FUNKTIONEN

//////////////////////////////////////////////////////////////////////////////////////////
// ==============
// COLLISION / TRIGGER FUNKTIONEN
// ==============
//{///////////////////////////////////////////////////////////////////////////////////////

//-------------------------------------------------------

	////////////////////////////
	// Kollisionsabfrage ob die Kugel den aktivierten blauen Cube berührt
	void OnCollisionEnter (Collision col) {
			
		// Wird geprüft ob der Cube oben ist sprich schon einmal aktiviert wurde
		if (upCube != true) {

			// Switchabfrage für die Position des Cubes + die korrekte Berechnung der neuen Position
			switch (_cubeLocation.location)
			{
			case 0: // GroundToTop
				PlaySoundFX (0);
				StartCoroutine(Animate(groundToTop));
				col.rigidbody.AddForce (Vector3.up * jumpForce);
				break;

			case 1: // TopToGround
				PlaySoundFX (0);
				StartCoroutine(Animate(topToGround));
				col.rigidbody.AddForce (-Vector3.up * jumpForce);
				break;

			case 2: // FrontToBack
				PlaySoundFX (0);
				StartCoroutine(Animate(frontToBack));
				col.rigidbody.AddForce (-Vector3.back * jumpForce);
				break;

			case 3: // BackToFront
				PlaySoundFX (0);
				StartCoroutine(Animate(backToFront));
				col.rigidbody.AddForce (Vector3.back * jumpForce);
				break;

			case 4: // LeftToRight
				PlaySoundFX (0);
				StartCoroutine(Animate(leftToRight));
				col.rigidbody.AddForce (-Vector3.forward * jumpForce);
				break;

			case 5: // RightToLeft
				PlaySoundFX (0);
				StartCoroutine(Animate(rightToLeft));
				col.rigidbody.AddForce (Vector3.forward * jumpForce);
				break;
			}

			upCube = true;

		}
	}

//-------------------------------------------------------

//} ENDE COLLISION / TRIGGER FUNKTIONEN

//////////////////////////////////////////////////////////////////////////////////////////
// ==============
// IENUMERATOR / ANIMATION
// ==============
//{///////////////////////////////////////////////////////////////////////////////////////

//-------------------------------------------------------

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
			_cubeLocation.isBusy = true;
			timeSinceStarted += Time.deltaTime * speed;
			transform.position = Vector3.Lerp(startPos, endPos, timeSinceStarted);
			yield return null;

		}

		// Nachdem der Timer zuende ist, ist der Cube wieder interagierbar und die Kollision ist deaktiviert
		_cubeLocation.isBusy = false;
		yield return new WaitForSeconds(0.1f);

	}

//-------------------------------------------------------

//} ENDE IENUMERATOR / ANIMATION

//////////////////////////////////////////////////////////////////////////////////////////
// ==============
// AUDIO
// ==============
//{///////////////////////////////////////////////////////////////////////////////////////

//-------------------------------------------------------

	void PlaySoundFX (int clip)
	{

		sourceFX.clip = clipFX [clip];
		sourceFX.Play();

	}

//-------------------------------------------------------

//} ENDE AUDIO

}