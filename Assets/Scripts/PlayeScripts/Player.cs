using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float speed = 8f, maxVelocity = 4f; //Velocidad de movimiento
    //[SerializeField] //Con esto podemos ver las variables.
    Rigidbody2D rb_player;
    Animator anim;

    void Awake() {
        Search();
    }

    void Search() {
        rb_player = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		}

    void FixedUpdate() {
        PlayerMoveKeyboard();
    }


    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(rb_player.velocity.x); //Nos da la velocidad del rigidbod
        Vector3 scale = this.transform.localScale;

        float h = Input.GetAxisRaw("Horizontal"); //Nos devuelve -1 izquierda, 0 si es nada, 1 si es derecha
        if (h > 0) //Vamos a la derecha
        {
            //Vemos si nuestra velocidad es velocidad maxima, para asi, seguir moviendonos.
            if (vel < maxVelocity)
            { //La velocidad es menor, puede seguir moviendose.
                forceX = speed;
            }

            anim.SetBool("Walk", true);
            scale.x = 1.3f;
            transform.localScale = scale;
        }
        else if (h < 0) //Vamos a la izquierda
        {
            if (vel < maxVelocity)
            {
                forceX = -speed;
            }

            anim.SetBool("Walk", true);
            scale.x = -1.3f;
			transform.localScale = scale;
        } else {
            anim.SetBool("Walk", false);
        }


        rb_player.AddForce(new Vector2(forceX, 0), ForceMode2D.Force); //Ojo con este force mode
    }
}
