using UnityEngine;
using System.Collections;

public class BackgroundScaler : MonoBehaviour {

	private void Start () {
		float height = Camera.main.orthographicSize * 2f;
		float width = height * Screen.width / Screen.height;

		if (gameObject.tag == "background") {
			transform.localScale = new Vector3 (width, height, 0);
		}

		if (gameObject.name == "ground") {
			transform.localScale = new Vector3 (width + 4, 4, 0);
		}
	}
}
