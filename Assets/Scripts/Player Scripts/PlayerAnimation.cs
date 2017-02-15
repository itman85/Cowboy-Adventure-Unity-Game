using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
	private Animator amin;
	// Use this for initialization
	void Start () {
		amin = GetComponent<Animator> ();
	}

	void OnCollisionEnter2D(Collision2D target){
		//print ("Enter");
		if (target.gameObject.tag == "Obstacle") {
			amin.Play ("Idle");
		}
	}

	void OnCollisionExit2D(Collision2D target){	
		//print ("Exit");	
		if (target.gameObject.tag == "Obstacle") {
			amin.Play ("Run");
		}

	}
	// Update is called once per frame
	void Update () {
		
	}
}
