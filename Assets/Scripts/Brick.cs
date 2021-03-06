﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public AudioClip boom;
	public AudioClip bump;
	public static int breakableCount;
	private int timesHit;
	private LevelManager levelmanager;
	private bool isBreakable;
	public Sprite[] hitSprites;
	public GameObject smoke;

	void Awake(){
		breakableCount = 0;
	}

	// Use this for initialization
	void Start () {
		
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		levelmanager = GameObject.FindObjectOfType<LevelManager> ();
	}


	void OnCollisionExit2D(Collision2D coll) {
		if (isBreakable) {
			HandleHits ();
		}
	}



	void HandleHits() {
		timesHit += 1;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			AudioSource.PlayClipAtPoint (boom, transform.position);
			breakableCount--;
			levelmanager.BrickDestroyed ();
			PuffSmoke ();
			Destroy (gameObject);
		} else {
			AudioSource.PlayClipAtPoint (bump, transform.position);
			LoadSprites ();
		}
	}

	void PuffSmoke() {
		GameObject puff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
		puff.GetComponent<ParticleSystem> ().startColor = this.GetComponent<SpriteRenderer> ().color;
		Destroy(puff, puff.GetComponent<ParticleSystem>().duration);
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError ("Brick Sprite missing");
		}
	}

	//Todo Remove method once we can actually win
	void SimulateWin() 
	{
		levelmanager.LoadNextLevel ();
	}
}
