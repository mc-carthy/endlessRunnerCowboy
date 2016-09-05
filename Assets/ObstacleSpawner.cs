using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] obstacles;

	private List<GameObject> obstaclesForSpawning = new List<GameObject>();

	private void Awake() {
		InitializeObstacles ();
	}

	private void Start () {
		StartCoroutine (SpawnObstacle ());
	}

	private void InitializeObstacles () {
		int index = 0;
		for (int i = 0; i < obstacles.Length * 3; i++) {
			GameObject obj = Instantiate (obstacles [index], transform.position, Quaternion.identity) as GameObject;
			obstaclesForSpawning.Add (obj);
			obstaclesForSpawning [i].SetActive (false);
			index++;
			if (index == obstacles.Length) {
				index = 0;
			}
		}
	}

	private void Shuffle () {
		for (int i = 0; i < obstaclesForSpawning.Count; i++) {
			GameObject temp = obstaclesForSpawning [i];
			int random = Random.Range (i, obstaclesForSpawning.Count);
			obstaclesForSpawning [i] = obstaclesForSpawning [random];
			obstaclesForSpawning [random] = temp;
		}
	}

	private IEnumerator SpawnObstacle () {
		yield return new WaitForSeconds(Random.Range(1.5f, 4.5f));

		int index = Random.Range(0, obstaclesForSpawning.Count);

		while (true) {
			if (!obstaclesForSpawning[index].activeInHierarchy) {
				obstaclesForSpawning[index].SetActive(true);
				obstaclesForSpawning [index].transform.position = new Vector2 (transform.position.x, transform.position.y);;
				break;
			} else {
				index = Random.Range(0, obstaclesForSpawning.Count);
			}
		}

		StartCoroutine (SpawnObstacle ());
	}
}
