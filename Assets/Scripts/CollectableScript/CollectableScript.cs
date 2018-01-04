using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour {

    void DestroyCollectable()
    {
        this.gameObject.SetActive(false);
    }

    private void OnEnable() {
        /*
         * Cuando el objeto entra en Enable, despues de 6 segundos se vuelve inactivo.  
         */
        //Invoke("DestroyCollectable", 6f);
        
    }
}
