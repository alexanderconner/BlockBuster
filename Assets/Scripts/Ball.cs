using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public bool hasStarted = false;
	private Paddle paddle;

	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print (paddleToBallVector.y);

	}
	
	// Update is called once per frame
	void Update () {
		if (hasStarted == false) {
			//Move ball relative to paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
		
			if (Input.GetMouseButtonDown (0)) {
				print ("mouse clicked, launch ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//Vector2 tweak = new Vector2 (Random.Range(0.f, 0.2f), Random.Range(0f, 0.2f));
		Vector2 tweak = new Vector2 (Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f));

		AudioSource audio = GetComponent<AudioSource> ();
		if(hasStarted)
		{
			audio.Play ();
			//rigidbody.velocity += tweak;
			GetComponent<Rigidbody2D> ().velocity += tweak;
		}
	}
}
