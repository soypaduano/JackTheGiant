using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Spawner : MonoBehaviour {

    GameObject[] backgrounds;
    float lastY;

	// Use this for initialization
	void Start () {
        getBackgroundAndSetLastY();
	}

    void getBackgroundAndSetLastY()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        lastY = backgrounds[0].transform.position.y;

        //Hacemos este bucle para ver la posicion Y mas alta, ya que cuando guardamos
        //background, nos lo guarda de una manera desordenada.
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (lastY > backgrounds[i].transform.position.y)
            {
                lastY = backgrounds[i].transform.position.y;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Background")
        {
            if (target.transform.position.y == lastY) //Si choca con el ultimo....
            {
                print("ESTA ENTRANDO EN EL ULTIMO");
                Vector2 temp = target.transform.position;
                float height = ((BoxCollider2D)target).size.y; //Guardamos la altura porque es justo la distancia que lo queremos mover.

                for (int i = 0; i < backgrounds.Length; i++)
                {
                    if (!backgrounds[i].activeInHierarchy){
                        temp.y -= height;
                        lastY = temp.y;
                        backgrounds[i].transform.position = temp;
                        backgrounds[i].SetActive(true);
                    }
                }
            }
        }
    }


}
