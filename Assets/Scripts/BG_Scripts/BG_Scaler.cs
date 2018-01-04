using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scaler : MonoBehaviour {

	void Start () {
       SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        Vector3 bgScale = this.transform.localScale; //Escala del objeto actual
        float width = spriteRenderer.sprite.bounds.size.x;
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight / Screen.height * Screen.width;

        bgScale.x = worldWidth / width;
        transform.localScale = bgScale;


	}
}
