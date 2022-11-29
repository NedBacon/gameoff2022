using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelGame : MonoBehaviour {

    public string ourObject; // Should be the same as ClickedObject.thisObject
    public SpriteRenderer[] panelBacks;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public GameObject textPF;
    public GameObject iconWin;
    PanelManager panelM;
    private Transform dragButtonGroup;
    private GameObject textGO;
    private string currentGame;
    public static int buttonsAmount;
    public static bool allCollected;

    private void Awake() {
        
        dragButtonGroup = GameObject.Find("Drag Buttons").transform;
        dragButtonGroup.gameObject.SetActive(false);

        panelM = GameObject.Find("_Manager").GetComponent<PanelManager>();

        buttonsAmount = 5;
        allCollected = false;

    }
    
    private void OnEnable() {
        
        // textGO = GameObject.Instantiate(textPF, new Vector3(0, 0, 90), Quaternion.identity, GameObject.Find("Canvas").transform);
        
        switch(Random.Range(0, 4)) {
            case 0 :
                Game0();
                break;
            case 1 :
                Game1();
                break;
            case 2 :
                Game2();
                break;
            case 3 :
                Game3();
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
        // textGO.GetComponent<TextMeshProUGUI>().text = "Upgame " + ourObject;

        // set up drag buttons in random places
        dragButtonGroup.gameObject.SetActive(true);
        for(int i = 0; i < buttonsAmount; i ++) {
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
        // textGO.GetComponent<TextMeshProUGUI>().text = "Downgame " + ourObject;

        foreach(SpriteRenderer panelSR in panelBacks) {
            if(panelSR.gameObject.activeSelf) {
                panelSR.sprite = downSprite;
            }
        }

        // set up drag buttons in random places
        dragButtonGroup.gameObject.SetActive(true);
        for(int i = 0; i < buttonsAmount; i ++) {
            GameObject button = dragButtonGroup.GetChild(i).gameObject;
            button.transform.position = new Vector3(Random.Range(-6f, 6f), Random.Range(-3f, 3f), 90);
        }

    }

    private void Game2() {

        currentGame = "leftgame";
        // textGO.GetComponent<TextMeshProUGUI>().text = "Leftgame " + ourObject;

        foreach(SpriteRenderer panelSR in panelBacks) {
            if(panelSR.gameObject.activeSelf) {
                panelSR.sprite = leftSprite;
            }
        }

        // set up drag buttons in random places
        dragButtonGroup.gameObject.SetActive(true);
        for(int i = 0; i < buttonsAmount; i ++) {
            GameObject button = dragButtonGroup.GetChild(i).gameObject;
            button.transform.position = new Vector3(Random.Range(-6f, 6f), Random.Range(-3f, 3f), 90);
        }

    }

    private void Game3() {

        currentGame = "rightgame";
        // textGO.GetComponent<TextMeshProUGUI>().text = "Rightgame " + ourObject;

        foreach(SpriteRenderer panelSR in panelBacks) {
            if(panelSR.gameObject.activeSelf) {
                panelSR.sprite = rightSprite;
            }
        }

        // set up drag buttons in random places
        dragButtonGroup.gameObject.SetActive(true);
        for(int i = 0; i < buttonsAmount; i ++) {
            GameObject button = dragButtonGroup.GetChild(i).gameObject;
            button.transform.position = new Vector3(Random.Range(-6f, 6f), Random.Range(-3f, 3f), 90);
        }

    }

    private void Update() {
        
        switch(currentGame) {

            case "upgame" :
                for(int i = 1; i < buttonsAmount; i ++) {
                    float lastPos = dragButtonGroup.GetChild(i - 1).position.y;
                    float thisPos = dragButtonGroup.GetChild(i).position.y;
                    if(thisPos > lastPos - 0.25f || Input.GetMouseButton(0)) {
                        return;
                    }
                }
                Win();

            break;

            case "downgame" :
                for(int i = 1; i < buttonsAmount; i ++) {
                    float lastPos = dragButtonGroup.GetChild(i - 1).position.y;
                    float thisPos = dragButtonGroup.GetChild(i).position.y;
                    if(thisPos < lastPos + 0.25f || Input.GetMouseButton(0)) {
                        return;
                    }
                }
                Win();

            break;

            case "leftgame" :
                for(int i = 1; i < buttonsAmount; i ++) {
                    float lastPos = dragButtonGroup.GetChild(i - 1).position.x;
                    float thisPos = dragButtonGroup.GetChild(i).position.x;
                    if(thisPos < lastPos + 0.25f || Input.GetMouseButton(0)) {
                        return;
                    }
                }
                Win();

            break;

            case "rightgame" :
                for(int i = 1; i < buttonsAmount; i ++) {
                    float lastPos = dragButtonGroup.GetChild(i - 1).position.x;
                    float thisPos = dragButtonGroup.GetChild(i).position.x;
                    if(thisPos > lastPos - 0.25f || Input.GetMouseButton(0)) {
                        return;
                    }
                }
                Win();

            break;

        }

    }

    void Win() {

        if(!PanelManager.debuffsGO.activeSelf) {
            PanelManager.debuffsGO.SetActive(true);
        }
        if(allCollected) {
            iconWin.SetActive(true);
        }
        panelM.ClosePanel();

    }

}
