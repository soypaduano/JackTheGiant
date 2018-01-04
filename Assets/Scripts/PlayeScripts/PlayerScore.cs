using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    [SerializeField]
    AudioClip lifeClip, coinClip;

    CameraScript cameraScript;
    Vector3 previousPosition; //Es una referencia para saber si el jugador ha bajado en el eje Y
    bool countScore;
    public static int lifeCount;
    public static int coinCount;
    public static int scoreCount;

    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }

    void Start () {
        previousPosition = this.transform.position;
        countScore = true;
	}

    //TODO: Pasa a esto al script de player, no entiendo porque va aqui
    void OnTriggerEnter2D(Collider2D target) //Comprobacion de choques con objetos
    {
        if (target.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200;
            GameplayController.instance.setCoinScore(coinCount);
            GameplayController.instance.setScore(scoreCount);
            AudioSource.PlayClipAtPoint(coinClip, this.transform.position);
            target.gameObject.SetActive(false);
        } else if (target.tag == "Life") {
            lifeCount++;
            scoreCount += 300;
            GameplayController.instance.setLifeScore(lifeCount);
            GameplayController.instance.setScore(scoreCount);
            AudioSource.PlayClipAtPoint(lifeClip, this.transform.position);
            target.gameObject.SetActive(false);
        } else if (target.tag == "Bound") {
            cameraScript.moveCamera = false;
            countScore = false;
            lifeCount--;
            this.gameObject.SetActive(false);
            Game_Manager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
        }else if (target.tag == "Deadly") {
			cameraScript.moveCamera = false;
			countScore = false;
			lifeCount--;
			this.gameObject.SetActive(false);
            print("EL SCORE COUNT AL CHOCAR ES... " + scoreCount);
            print("EL COIN COUNT AL CHOCAR ES... " + coinCount);
            Game_Manager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
        } 
    }

    void Update () {
        countPosition();
	}

    void countPosition()
    {
        if (countScore)
        {
            if (this.transform.position.y < previousPosition.y) //Si ha bajado...
            {
                scoreCount++;
            }
            previousPosition = this.transform.position;
            GameplayController.instance.setScore(scoreCount);
        }
    }
}
