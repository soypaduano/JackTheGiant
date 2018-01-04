using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour {

    float minX, maxX;

    private void Start()
    {
        setBorders();
    }

    void setBorders() {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        maxX = bounds.x;
        minX = -bounds.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x < minX)
        {
            print("ENTRA AQUI, CUANDO SE VA POR LA IZQUIERDA");
            Vector3 temp = transform.position;
            temp.x = minX;
            this.transform.position = temp;
        }

        if (this.transform.position.x > maxX)
		{
            print("ENTRA AQUI, CUANDO SE VA POR LA DERECHA");
			Vector3 temp = transform.position;
            temp.x = maxX;
			this.transform.position = temp;
		}


	}
}
