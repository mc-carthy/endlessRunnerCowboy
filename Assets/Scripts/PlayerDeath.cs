using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	public delegate void EndGame ();
	public static event EndGame endGame;

	private void PlayerDiedEndGame () {
		if (endGame != null) {
			endGame ();
		}
		Destroy (gameObject);
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.tag == "collector") {
			PlayerDiedEndGame ();
		}
	}

	private void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "zombie") {
			PlayerDiedEndGame ();
		}
	}
}
