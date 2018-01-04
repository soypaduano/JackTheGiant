using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] nubes;
    float distanceBetweenClouds = 3f;
    float minX, maxX; //Estas variables serviran para saber los maximos y minimos de la pantalla para poner las nubes.
    float lastCloudPositionY;
	[SerializeField]
    GameObject[] collectables;
    float ControlX;
    GameObject player;


    private void Awake()
    {
        ControlX = 0;
        setBorders();
        createClouds();
        PositionThePlayer();
        SetActiveCollectables(false);
    }

    void SetActiveCollectables(bool active) {
        for (int i = 0; i < collectables.Length; i++) {
            collectables[i].SetActive(active);
        }
    }

    void setBorders() {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }

    void createClouds() {
       
        Shuffle(nubes);
		float positionY = 0;
        for (int i = 0; i < nubes.Length; i++)
        {
            Vector3 temp = nubes[i].transform.position;
            temp.y = positionY;

            if (ControlX == 0){
                temp.x = Random.Range(0.0f, maxX);
                ControlX = 1;
            }else if (ControlX == 1){
                temp.x = Random.Range(0.0f, minX);
                ControlX = 2;
            }else if (ControlX == 2){
                temp.x = Random.Range(1.0f, minX);
                ControlX = 3;
            }else if (ControlX == 3){
                temp.x = Random.Range(-1.0f, minX);
                ControlX = 0;
            }

            lastCloudPositionY = positionY;
            positionY -= distanceBetweenClouds;
            nubes[i].transform.position = temp;
            int random = Random.Range(0, collectables.Length);
            if (nubes[i].tag != "Deadly")
            {
                if (!collectables[random].activeInHierarchy)
                {
                    Vector3 temp2 = nubes[i].transform.position;
                    temp2.y += 0.7f;

                    if (collectables[random].tag == "Life")
                    {
                        if (PlayerScore.lifeCount < 2)
                        {
                            collectables[random].transform.position = temp2;
                            collectables[random].SetActive(true);
                        }
                    }
                    else
                    {
              
                        collectables[random].transform.position = temp2;
                        collectables[random].SetActive(true);
                    }
                }
            }
        }
    }

    void Shuffle(GameObject[] arrayToShuffle)
    {
        for (int i = 0; i < arrayToShuffle.Length; i++) {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }
    }

    void PositionThePlayer() {
        while (nubes[0].tag == "Deadly")
        {
            Shuffle(nubes);
        }
        player = GameObject.Find("Player");
        player.transform.position = new Vector3(nubes[0].transform.position.x, nubes[0].transform.position.y + 1.0f, 0);  
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Deadly" || target.tag == "Cloud" ) //Vamos a comprobar si es la ultima nube
        {
            if (target.transform.position.y == lastCloudPositionY) {
                Shuffle(nubes); //Volvemos a mezclar las nubes
                //Shuffle(collectables); //Mezclamos los objetos recolectables
                Vector3 temp = target.transform.position;

                for (int i = 0; i < nubes.Length; i++) {

                    if (!nubes[i].activeInHierarchy) {
						if (ControlX == 0)
						{
							temp.x = Random.Range(0.0f, maxX);
							ControlX = 1;
						}
						else if (ControlX == 1)
						{
							temp.x = Random.Range(0.0f, minX);
							ControlX = 2;
						}
						else if (ControlX == 2)
						{
							temp.x = Random.Range(1.0f, minX);
							ControlX = 3;
						}
						else if (ControlX == 3)
						{
							temp.x = Random.Range(-1.0f, minX);
							ControlX = 0;
						}

                        temp.y -= distanceBetweenClouds;
                        lastCloudPositionY = temp.y;   
                        nubes[i].transform.position = temp;
                        nubes[i].SetActive(true);
						int random = Random.Range(0, collectables.Length);
						if (nubes[i].tag != "Deadly")
						{

							print("ENTRA AQUI, EN LA CREACION DE UNA NUBE NO DEADLY");
							if (!collectables[random].activeInHierarchy)
							{
								Vector3 temp2 = nubes[i].transform.position;
								temp2.y += 0.7f;

								if (collectables[random].tag == "Life")
								{
									if (PlayerScore.lifeCount < 2)
									{
										collectables[random].transform.position = temp2;
										collectables[random].SetActive(true);
									}
								}
								else
								{
									print("ENTRA AQUI, EN LA CREACION DE MONEDAS");
									collectables[random].transform.position = temp2;
									collectables[random].SetActive(true);
								}
							}
						}
						else
						{
							print("SON NUBES DEADLY");
						}
                    }
                }
            }
        }
    }
}
