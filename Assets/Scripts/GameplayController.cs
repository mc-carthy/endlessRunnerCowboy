using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameplayController : MonoBehaviour {

	[SerializeField]
	private GameObject pausePanel;
	[SerializeField]
	private Button restartGameButton;
	[SerializeField]
	private Text scoreText, pauseText;
	private int score = 0;

	private void Start () {
		SetScore ();
		StartCoroutine (CountScore ());
		pausePanel.SetActive (false);
	}

	private void OnEnable () {
		PlayerDeath.endGame += PlayerDiedEndGame;
	}

	private void OnDisnable () {
		PlayerDeath.endGame -= PlayerDiedEndGame;
	}

	public void RestartGame () {
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name, LoadSceneMode.Single);
	}

	public void ResumeGame () {
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void PauseGame () {
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		restartGameButton.onClick.RemoveAllListeners ();
		restartGameButton.onClick.AddListener (() => ResumeGame ());
	}

	public void GoToMenu () {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("menu", LoadSceneMode.Single);
	}

	private IEnumerator CountScore () {
		yield return new WaitForSeconds (0.6f);
		score++;
		SetScore ();
		StartCoroutine (CountScore ());
	}

	private void SetScore () {
		scoreText.text = score + "M";
	}

	private void PlayerDiedEndGame () {
		if (PlayerPrefs.HasKey ("highScore")) {
			PlayerPrefs.SetInt ("highScore", 0);
		} else {
			int highScore = PlayerPrefs.GetInt ("highScore");
			if (score > highScore) {
				PlayerPrefs.SetInt ("highScore", score);
			}
		}
		Time.timeScale = 0f;
		pauseText.text = "Game Over";
		pausePanel.gameObject.SetActive (true);
		restartGameButton.onClick.RemoveAllListeners ();
		restartGameButton.onClick.AddListener (() => RestartGame());
	}
}
