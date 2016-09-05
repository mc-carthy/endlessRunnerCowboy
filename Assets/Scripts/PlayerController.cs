using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private AudioClip jumpClip;
	private Rigidbody2D rb;
	private float jumpForce = 12f, forwardForce = 0f;
	private bool canJump;
	private Button jumpBtn;

	private void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		jumpBtn = GameObject.Find ("jumpButton").GetComponent<Button> ();
		jumpBtn.onClick.AddListener (() => Jump ());
	}

	private void Update () {
		if (rb.velocity.y == 0) {
			canJump = true;
		}
	}

	public void Jump () {
		if (canJump) {
			canJump = false;
			if (transform.position.x < 0) {
				forwardForce = 1f;
			} else {
				forwardForce = 0f;
			}
			rb.velocity = new Vector2 (forwardForce, jumpForce);
			//AudioSource.PlayClipAtPoint (jumpClip, transform.position);
		}
	}
}
