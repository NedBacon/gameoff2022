using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

    private bool panelOpen;
    private GameObject cancelObject;
    private PanelGame[] panels;

    private void Awake() {
        
        // or just add it all in inspector?
        cancelObject = GameObject.Find("x");
        panels = new PanelGame[cancelObject.transform.childCount];
        for(int i = 0; i < cancelObject.transform.childCount; i++) {
            PanelGame child = cancelObject.transform.GetChild(i).gameObject.GetComponent<PanelGame>();
            panels[i] = child;
            child.gameObject.SetActive(false);
        }
        cancelObject.SetActive(false);

    }

    public void OpenPanel(string objectClicked) {

        if(!panelOpen) {

            panelOpen = true;
            foreach(PanelGame panel in panels) {
                if(objectClicked == panel.panelID) {
                    Debug.Log(panel.gameObject.name);
                    panel.gameObject.SetActive(true);
                    cancelObject.SetActive(true);
                }
            }

        }

    }

    public void ClosePanel() {

        if(!panelOpen) {
            return;
        }
        panelOpen = false;
        foreach(Transform child in cancelObject.GetComponentInChildren<Transform>()) {
            child.gameObject.SetActive(false);
        }
        cancelObject.SetActive(false);

    }
    
}
