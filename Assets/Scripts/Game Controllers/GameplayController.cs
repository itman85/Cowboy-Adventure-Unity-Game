using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

	[SerializeField]
	private GameObject pausePanel;

	[SerializeField]
	private Button restartGameButton;

	[SerializeField]
	private Text scoreText, pauseText;

	private int score;
	private bool isGameOver;

	void Start () {
		scoreText.text = score + "M";
		isGameOver = false;
		StartCoroutine (CountScore());
	}

	IEnumerator CountScore() {
		yield return new WaitForSeconds(0.6f);
		score++;
		scoreText.text = score + "M";
		StartCoroutine (CountScore());
	}

	void OnEnable() {
		PlayerDied.endGame += PlayerDiedEndTheGame;
	}

	void OnDisable() {
		PlayerDied.endGame -= PlayerDiedEndTheGame;
	}

	void PlayerDiedEndTheGame() {

		if (!PlayerPrefs.HasKey ("Score")) {
			PlayerPrefs.SetInt("Score", 0);
		} else {
			int highscore = PlayerPrefs.GetInt("Score");

			if(highscore < score) {
				PlayerPrefs.SetInt("Score", score);
			}
		}
		isGameOver = true;
		pauseText.text = "Game Over";
		//print ("pause text:" + pauseText.text);
		pausePanel.SetActive (true);
		restartGameButton.onClick.RemoveAllListeners ();
		restartGameButton.onClick.AddListener (() => RestartGame());
		Time.timeScale = 0f;

	}

	public void PauseButton() {
		if (!isGameOver) {
			Time.timeScale = 0f;//timer pause
			pauseText.text = "Pause";
			//print ("pause text:" + pauseText.text);
			pausePanel.SetActive (true);
			restartGameButton.onClick.RemoveAllListeners ();
			restartGameButton.onClick.AddListener (() => ResumeGame ());
		}
	}

	public void GoToMenu() {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}

	public void ResumeGame() {
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void RestartGame() {
		Time.timeScale = 1f;
		isGameOver = false;
		SceneManager.LoadScene ("Gameplay", LoadSceneMode.Single);
	}

}
