using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	float mousePosInBlocks;
	Vector3 paddlePos;
	float xMinValue = 0.5f;
	float xMaxValue = 15.5f;

	public bool autoPlay = false;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay();
		}
	}

	void AutoPlay() {
		paddlePos = new Vector3 (0.5f, this.transform.position.y, 0.0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, xMinValue, xMaxValue);
		this.transform.position = paddlePos;
	}

	void MoveWithMouse (){
		paddlePos = new Vector3 (0.5f, this.transform.position.y, 0.0f);
		mousePosInBlocks =( Input.mousePosition.x / Screen.width * 16);
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, xMinValue, xMaxValue);
		this.transform.position = paddlePos;
	}

}
