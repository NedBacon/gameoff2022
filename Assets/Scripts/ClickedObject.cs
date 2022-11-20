using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedObject : MonoBehaviour {

    public string thisObject;
    PanelManager panelM;
    
    private void Awake() {

        panelM = GameObject.Find("_Manager").GetComponent<PanelManager>();

    }

    private void OnMouseOver() {

        if(Input.GetMouseButtonDown(0)) {
            if(thisObject == "x") {
                panelM.ClosePanel();
            } else {
                panelM.OpenPanel(thisObject);
            }
        }

    }

}