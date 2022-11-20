using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

    private bool panelOpen;
    private GameObject cancelObject;
    private GameObject panelGameGO;
    private GameObject[] panels;

    private void Awake() {
        
        // or just add it all in inspector?
        cancelObject = GameObject.Find("x");

        panels = new GameObject[cancelObject.transform.childCount];
        for(int i = 0; i < cancelObject.transform.childCount; i++) {
            GameObject child = cancelObject.transform.GetChild(i).gameObject;
            panels[i] = child;
            child.gameObject.SetActive(false);
        }

        cancelObject.SetActive(false);

        panelGameGO = GameObject.Find("_Manager/_Panels");
        panelGameGO.SetActive(false);
        

    }

    public void OpenPanel(string objectClicked) {

        if(!panelOpen) {

            panelOpen = true;

            // construct string that panel GO name has to follow, check against all panels
            string panelID = objectClicked.Trim().ToUpper() + " PANEL";

            foreach(GameObject panel in panels) {
                if(panelID == panel.gameObject.name.Trim().ToUpper()) {
                    panel.gameObject.SetActive(true);
                    cancelObject.SetActive(true);
                }
            }

            panelGameGO.GetComponent<PanelGame>().ourObject = objectClicked;
            panelGameGO.SetActive(true);
            foreach(ClickedObject thingy in FindObjectsOfType<ClickedObject>(true)) {
                if(thingy.thisObject != "x") {
                    thingy.gameObject.SetActive(false);
                }
            }

        }

    }

    public void ClosePanel() {

        if(!panelOpen) {
            return;
        }
        panelOpen = false;
        foreach(Transform child in cancelObject.GetComponentInChildren<Transform>()) { // each object's panel
            child.gameObject.SetActive(false);
        }
        cancelObject.SetActive(false);
        panelGameGO.SetActive(false);
        foreach(ClickedObject thingy in FindObjectsOfType<ClickedObject>(true)) {
            if(thingy.thisObject != "x") {
                thingy.gameObject.SetActive(true);
            }
        }

    }
    
}
