using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameplayController : MonoBehaviour {

    public static GameplayController instance;
    Text scoreText, coinText, lifeText, gameOverScore, gameOverCoins;
    GameObject pausePanel, gameOverPanel;
    Button readyStart;

    void makeInstance() {
        if (instance == null) {
            instance = this;
        }
    }

     void Awake()
    {
        makeInstance();
        SearchObjects();
    }

    void Start()
    {
        Time.timeScale = 0f;
    }


    public void StartGame()
    {
        Time.timeScale = 1f;
        readyStart.gameObject.SetActive(false);
    }

    void SearchObjects() {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        coinText = GameObject.Find("CoinsText").GetComponent<Text>();
        lifeText = GameObject.Find("LivesText").GetComponent<Text>(); 
        gameOverCoins = GameObject.Find("GameOverCoins").GetComponent<Text>();
        gameOverScore = GameObject.Find("GameOverText").GetComponent<Text>();
        pausePanel = GameObject.Find("PausePanel");
        gameOverPanel = GameObject.Find("GameOverpanel");
        readyStart = GameObject.Find("ReadyButton").GetComponent<Button>();
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        string x = GamePreferences.difficulty.EASY;

    }

    public void GameOverShow(int _finalScore, int _finalCoins)
    {
        print("Lanzamos el anuncio de Game Over");
        gameOverPanel.SetActive(true);
        gameOverScore.text = "x" + _finalScore;
        gameOverCoins.text = "x" + _finalCoins;
        StartCoroutine(GoBackAfterGameOver());
    }

    public void PlayerDiedRestart() {
        StartCoroutine(PlayerDiedRestartCoroutine());
    }

    IEnumerator GoBackAfterGameOver()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator PlayerDiedRestartCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("escenaJuego");
    }

    public void setScore(int _score)
    {
        scoreText.text = "x" + _score;
    }

    public void setCoinScore(int _coinScore)
    {
        coinText.text = "x" + _coinScore;
    }

    public void setLifeScore(int _lifeScore)
	{
        lifeText.text = "x" + _lifeScore;
	}

    public void PauseTheGame() {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);

    }

    public void QuitGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
