using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragButton : MonoBehaviour {

    Vector3 posDiff;
    Vector3 tempMousePos;
    Camera theCam;

    private void Awake() {
        theCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void OnMouseOver() {

        tempMousePos = theCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

    }

    private void OnMouseDrag() {

        posDiff = theCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) - tempMousePos;
        if(tempMousePos.x > 6.5f || tempMousePos.x < -6.5f) {
            posDiff.x = 0;
        }
        if(tempMousePos.y > 3.5f || tempMousePos.y < -2.8f) {
            posDiff.y = 0;
        }
        this.transform.position += posDiff;
        tempMousePos = theCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

    }

    private void OnMouseUp() {

        posDiff = Vector3.zero;
        
    }

}
