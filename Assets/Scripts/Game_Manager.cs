using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour {

    public static Game_Manager instance;
    bool GameStartedFromMainMenu, GameRestartedAfterPlayerDied;
    public int coinScore, score, lifeScore;

	void Start () {
		if (instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

    public bool GetGameStartedFromMainMenu()
    {
        return GameStartedFromMainMenu;
    }

    public void SetGameStartedFromMainMenu(bool _GameStartedFromMainMenu)
	{
        this.GameStartedFromMainMenu = _GameStartedFromMainMenu;
	}


	public bool GetGameRestartedAfterPlayerDied()
	{
		return GameRestartedAfterPlayerDied;
	}

	public void SetGameRestartedAfterPlayerDied(bool _GameRestartedAfterPlayerDied)
	{
		this.GameRestartedAfterPlayerDied = _GameRestartedAfterPlayerDied;
	}

    public void CheckGameStatus(int _score, int _coinScore, int _lifeScore)
    {
        if (_lifeScore <= 0)
        {
            GameStartedFromMainMenu = false;
            GameRestartedAfterPlayerDied = false;
            GameplayController.instance.GameOverShow(score, coinScore);
        } else {
            GameStartedFromMainMenu = false;
            GameRestartedAfterPlayerDied = true;
            this.score = _score;
            this.coinScore = _coinScore;
            this.lifeScore = _lifeScore;
            GameplayController.instance.PlayerDiedRestart();

        }
    }


	// called second
	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == "escenaJuego") {
            if (GameRestartedAfterPlayerDied) {
                GameplayController.instance.setScore(score);
                GameplayController.instance.setCoinScore(coinScore);
                GameplayController.instance.setLifeScore(lifeScore);
                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;
            } else if (GameStartedFromMainMenu) {
                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;
				GameplayController.instance.setScore(0);
				GameplayController.instance.setCoinScore(0);
				GameplayController.instance.setLifeScore(2);
            }
        }
	}

}
