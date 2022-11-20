using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelGame : MonoBehaviour {

    public string ourObject; // Should be the same as ClickedObject.thisObject
    public SpriteRenderer[] panelBacks;
    public Sprite upSprite;
    public Sprite downSprite;
    public GameObject textPF;
    PanelManager panelM;
    private Transform dragButtonGroup;
    private GameObject textGO;
    private string currentGame;

    private void Awake() {
        
        dragButtonGroup = GameObject.Find("Drag Buttons").transform;
        dragButtonGroup.gameObject.SetActive(false);

        panelM = GameObject.Find("_Manager").GetComponent<PanelManager>();

    }
    
    private void OnEnable() {
        
        textGO = GameObject.Instantiate(textPF, new Vector3(0, 0, 90), Quaternion.identity, GameObject.Find("Text Stuff/Canvas").transform);
        
        switch(Random.Range(0, 2)) {
            case 0 :
                Game0();
                break;
            case 1 :
                Game1();
                break;
        }

    }

    private void OnDisable() {
        
        currentGame = null;
        dragButtonGroup.gameObject.SetActive(false);
        if(textGO != null) {
            Transform.Destroy(textGO);
        }

    }



    private void Game0() {
        
        currentGame = "upgame";
        textGO.GetComponent<TextMeshProUGUI>().text = "Upgame " + ourObject;

        // set up drag buttons in random places
        dragButtonGroup.gameObject.SetActive(true);
        for(int i = 0; i < dragButtonGroup.childCount; i ++) {
            GameObject button = dragButtonGroup.GetChild(i).gameObject;
            button.transform.position = new Vector3(Random.Range(-6f, 6f), Random.Range(-3f, 3f), 90);
        }

        foreach(SpriteRenderer panelSR in panelBacks) {
            if(panelSR.gameObject.activeSelf) {
                panelSR.sprite = upSprite;
            }
        }

    }

    private void Game1() {

        currentGame = "downgame";
        textGO.GetComponent<TextMeshProUGUI>().text = "Downgame " + ourObject;

        foreach(SpriteRenderer panelSR in panelBacks) {
            if(panelSR.gameObject.activeSelf) {
                panelSR.sprite = downSprite;
            }
        }

        // set up drag buttons in random places
        dragButtonGroup.gameObject.SetActive(true);
        for(int i = 0; i < dragButtonGroup.childCount; i ++) {
            GameObject button = dragButtonGroup.GetChild(i).gameObject;
            button.transform.position = new Vector3(Random.Range(-6f, 6f), Random.Range(-3f, 3f), 90);
        }


    }

    private void Update() {
        
        switch(currentGame) {

            case "upgame" :
                for(int i = 1; i < dragButtonGroup.childCount; i ++) {
                    float lastPos = dragButtonGroup.GetChild(i - 1).position.y;
                    float thisPos = dragButtonGroup.GetChild(i).position.y;
                    if(thisPos > lastPos - 0.15f) {
                        return;
                    }
                }
                panelM.ClosePanel();

            break;

            case "downgame" :
                for(int i = 1; i < dragButtonGroup.childCount; i ++) {
                    float lastPos = dragButtonGroup.GetChild(i - 1).position.y;
                    float thisPos = dragButtonGroup.GetChild(i).position.y;
                    if(thisPos < lastPos + 0.15f) {
                        return;
                    }
                }
                panelM.ClosePanel();

            break;

        }

    }

}
