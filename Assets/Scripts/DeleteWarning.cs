using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DeleteWarning : MonoBehaviour {

    private void Update() {

        if(Input.anyKey) {
            Debug.Log("pain");
            GameObject.Destroy(this.gameObject);
        }

    }

    
    
}
