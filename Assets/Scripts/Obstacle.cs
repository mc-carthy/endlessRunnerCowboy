using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private float speed = -5f;

	private Rigidbody2D rb;

	private void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}

	private void Update () {
		rb.velocity = new Vector2 (speed, 0);
	}
}
