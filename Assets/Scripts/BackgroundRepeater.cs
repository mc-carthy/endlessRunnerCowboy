using UnityEngine;
using System.Collections;

public class BackgroundRepeater : MonoBehaviour {

	public float speed = 0.1f;

	private Vector2 offset = Vector2.zero;
	private Material mat;

	private void Start () {
		mat = GetComponent<Renderer> ().material;
		offset = mat.GetTextureOffset ("_MainTex");
	}

	private void Update () {
		offset.x += speed * Time.deltaTime;
		mat.SetTextureOffset ("_MainTex", offset);
	}
}
