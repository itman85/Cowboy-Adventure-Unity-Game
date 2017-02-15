using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour {
	[SerializeField]
	private AudioClip jumpClip;
	private float jumpForce = 12f, forwardForce = 0f;
	private Rigidbody2D myBody;
	private bool canJump;
	private Button jumpBtn;

	// Use this for initialization
	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
		jumpBtn = GameObject.Find ("Jump Button").GetComponent<Button> ();
		jumpBtn.onClick.AddListener (() => Jump ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (myBody.velocity.y) == 0) {
			canJump = true;
		}
	}

	public void Jump(){
		if (canJump) {
			canJump = false;
			if (transform.position.x < 0) {
				forwardForce = 1f;
			} else {
				forwardForce = 0f;
			}
			myBody.velocity = new Vector2 (forwardForce,jumpForce);
		}
	}
}
