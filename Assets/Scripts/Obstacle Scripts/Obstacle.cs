using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	private float speed = -3f;
	private Rigidbody2D myBody;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();	
	}
	
	// Update is called once per frame
	void Update () {
		//print ("move");
		myBody.velocity = new Vector2 (speed, 0f);
	}
}
