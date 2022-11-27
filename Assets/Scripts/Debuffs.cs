using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Debuffs : MonoBehaviour {

    public Slider slider;
    public int seconds;
    public List<string> debuffs;
    public Image colorTint;
    public GameObject announcePF;
    private GameObject announceGO;
    public GameObject eyesGO;

    public GameObject iconColor;
    public GameObject iconTiles;
    public GameObject iconTired;
    public GameObject iconWorkload;

    private void Awake() {
        
        debuffs = new List<string> {"button", "color"};

    }

    private void Update() {

        slider.value += Time.deltaTime / seconds;

        if(slider.value >= 1) {

            if(announceGO != null) {
                GameObject.Destroy(announceGO);
            }

            if(PanelManager.panelGameGO.activeSelf) {
                return;
            }

            announceGO = GameObject.Instantiate(announcePF, GameObject.Find("Canvas").transform);
            int r = Random.Range(0, debuffs.Count);
            switch(debuffs[r]) {
                case "nothing" :
                    announceGO.GetComponentInChildren<TextMeshProUGUI>().text = "Free Pass!";
                break;
                case "button" :
                    DebuffButton();
                break;
                case "color" :
                    DebuffColor();
                break;
                case "speed" :
                    DebuffSpeed();
                break;
                case "tired" :
                    DebuffSleep();
                break;
            }

            slider.value = 0;

        }

    }

    void DebuffButton() {

        PanelGame.buttonsAmount += 1;
        if(PanelGame.buttonsAmount == 8) {
            iconTiles.SetActive(true);
            debuffs.Remove("button");
            debuffs.Add("tired");
        }
        if(PanelGame.buttonsAmount == 7) {
            debuffs.Add("nothing");
            debuffs.Add("speed");
        }
        announceGO.GetComponentInChildren<TextMeshProUGUI>().text = PanelGame.buttonsAmount + " Tiles!";

    }

    void DebuffColor() {

        iconColor.SetActive(true);
        switch(Random.Range(0, 3)) {
            case 0 : 
                colorTint.color = new Color(0.7f, 0, 0.7f, 0.4f); // purple
                announceGO.GetComponentInChildren<TextMeshProUGUI>().text = "PURPLE!";
                iconColor.GetComponent<Image>().color = new Color(0.7f, 0, 0.7f);
            break;
            case 1 : 
                colorTint.color = new Color(0.7f, 0.7f, 0, 0.4f); // yellow
                announceGO.GetComponentInChildren<TextMeshProUGUI>().text = "YELLOW!";
                iconColor.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0);
            break;
            case 2 : 
                colorTint.color = new Color(0.7f, 0.35f, 0, 0.4f); // orange
                announceGO.GetComponentInChildren<TextMeshProUGUI>().text = "ORANGE!";
                iconColor.GetComponent<Image>().color = new Color(0.7f, 0.35f, 0);
            break;
        }

    }

    void DebuffSpeed() {

        int i = Random.Range(2, 4);
        if(seconds - i >= 3) {
            seconds -= i;
            announceGO.GetComponentInChildren<TextMeshProUGUI>().text = "Speed Up!";
        } else {
            seconds = 3;
            announceGO.GetComponentInChildren<TextMeshProUGUI>().text = "MAX SPEED!";
            debuffs.Remove("speed");
            iconWorkload.SetActive(true);
        }
        
    }

    void DebuffSleep() {

        eyesGO.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        announceGO.GetComponentInChildren<TextMeshProUGUI>().text = "Sleepy?";
        iconTired.SetActive(true);
        debuffs.Remove("tired");

    }

}
