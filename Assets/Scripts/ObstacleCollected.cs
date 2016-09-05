using UnityEngine;
using System.Collections;

public class ObstacleCollected : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.tag == "collector") {
			gameObject.SetActive (false);
		}
	}
}
