using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame() {
        Game_Manager.instance.SetGameStartedFromMainMenu(true);
        SceneManager.LoadScene("escenaJuego");
    }

    public void HighScoreScene()
    {
        SceneManager.LoadScene("Ranking");   
    }

    public void OptionsScene()
    {
        SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        //Salir del juego 
        //TODO
    }

    public void volumeButton()
    {
    }
}
