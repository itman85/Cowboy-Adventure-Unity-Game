using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDied : MonoBehaviour {

	public delegate void EndGame ();
	public static event EndGame endGame;
	// Use this for initialization
	void PlayerDiedEndGame () {
		if (endGame != null)
			endGame ();
		Destroy (gameObject);
		
	}

	void OnTriggerEnter2D(Collider2D target){
		print ("Enter");
		if (target.tag == "Collector") {
			PlayerDiedEndGame ();
		}
	}

	void OnCollisionEnter2D(Collision2D target){
		print ("Enter1");
		if (target.gameObject.tag == "Zombie")
			PlayerDiedEndGame ();
	}

}
