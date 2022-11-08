using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

    static private bool panelOpen;
    static private GameObject cancelObject;

    private void Awake() {
        
        cancelObject = GameObject.Find("x");
        cancelObject.SetActive(false);

    }

    static public void OpenPanel(string objectClicked) {

        if(!panelOpen) {

            panelOpen = true;
            cancelObject.SetActive(true);
            Sprite objectS = GameObject.Find("_Manager/_Sprites/" + objectClicked).GetComponent<SpriteRenderer>().sprite;
            cancelObject.transform.Find("item").GetComponent<SpriteRenderer>().sprite = objectS;
            Debug.Log("Opening Panel for " + objectClicked);

        }

    }

    static public void ClosePanel() {

        if(!panelOpen) {
            return;
        }
        panelOpen = false;
        cancelObject.SetActive(false);
        Debug.Log("Closing current panel");

    }
    
}
