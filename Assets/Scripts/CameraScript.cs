using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    float speed = 1f;
    float acceleration = 0.2f;
    float maxSpeed = 3.2f;

    public bool moveCamera;

	// Use this for initialization
	void Start () {
        moveCamera = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (moveCamera) {
            CameraMove();
        }
	}

    void CameraMove()
    {
        Vector3 temp = transform.position;
        float oldY = temp.y;
        float newY = temp.y - (speed * Time.deltaTime);
        temp.y = Mathf.Clamp(temp.y, oldY, newY);
        this.transform.position = temp;
        speed += acceleration * Time.deltaTime;
        if (speed > maxSpeed)
            speed = maxSpeed;
        
        
        }
}
