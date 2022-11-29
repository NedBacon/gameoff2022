using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Debuffs : MonoBehaviour {

    public Slider slider;
    public int seconds;
    public List<string> debuffs;
    private bool hungover;
    private bool hangoverDirection;
    private List<int> asdf; 
    private bool cogging;

    public Image colorTint;
    public GameObject announcePF;
    private GameObject announceGO;
    public GameObject eyesGO;
    public Camera cameraC;

    public GameObject iconColor;
    public GameObject iconTiles;
    public GameObject iconTired;
    public GameObject iconWorkload;
    public GameObject iconHangover;
    public GameObject iconSpin;

    private void Awake() {
        
        hungover = false;
        cogging = false;
        asdf = new List<int>();
        debuffs = new List<string> {"button", "color"};

    }

    private void Update() {

        slider.value += Time.deltaTime / seconds;

        if(asdf.Contains(0) && asdf.Contains(1) && asdf.Contains(2) && asdf.Contains(3)
        && asdf.Contains(4) && asdf.Contains(5) && asdf.Contains(6) && asdf.Contains(7) && asdf.Contains(8)) {
            PanelGame.allCollected = true;
        }

        if(hungover) {
            if(hangoverDirection) {
                cameraC.orthographicSize += 0.007f;
                if(cameraC.orthographicSize >= 7.2f) {
                    hangoverDirection = false;
                }
            } else {
                cameraC.orthographicSize -= 0.007f;
                if(cameraC.orthographicSize <= 3.5f) {
                    hangoverDirection = true;
                }        
            }
        }

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
                    asdf.Add(3);
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
                case "hangover" :
                    DebuffHangover();
                break;
                case "spin" :
                    DebuffSpin();
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
            asdf.Add(4);
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
                asdf.Add(0);
                colorTint.color = new Color(0.7f, 0, 0.7f, 0.4f); // purple
                announceGO.GetComponentInChildren<TextMeshProUGUI>().text = "PURPLE!";
                iconColor.GetComponent<Image>().color = new Color(0.7f, 0, 0.7f);
            break;
            case 1 :
                asdf.Add(1);
                colorTint.color = new Color(0.7f, 0.7f, 0, 0.4f); // yellow
                announceGO.GetComponentInChildren<TextMeshProUGUI>().text = "YELLOW!";
                iconColor.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0);
            break;
            case 2 :
                asdf.Add(2);
                colorTint.color = new Color(0.7f, 0.35f, 0, 0.4f); // orange
                announceGO.GetComponentInChildren<TextMeshProUGUI>().text = "ORANGE!";
                iconColor.GetComponent<Image>().color = new Color(0.7f, 0.35f, 0);
            break;
        }

        if(asdf.Contains(0) && asdf.Contains(1) && asdf.Contains(2) && cogging == false) {
            debuffs.Add("spin");
            cogging = true;
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
            asdf.Add(5);
            iconWorkload.SetActive(true);
        }
        
    }

    void DebuffSleep() {

        eyesGO.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        announceGO.GetComponentInChildren<TextMeshProUGUI>().text = "Sleepy?";
        iconTired.SetActive(true);
        debuffs.Remove("tired");
        asdf.Add(6);
        debuffs.Add("hangover");

    }

    void DebuffHangover() {

        hungover = true;
        hangoverDirection = true; // true means away from camera
        announceGO.GetComponentInChildren<TextMeshProUGUI>().text = "Dehydrated?";
        iconHangover.SetActive(true);
        debuffs.Remove("hangover");
        asdf.Add(7);

    }

    void DebuffSpin() {

        cameraC.gameObject.GetComponent<Animator>().Play("coggers");
        announceGO.GetComponentInChildren<TextMeshProUGUI>().text = "Do a barrel roll";
        iconSpin.SetActive(true);
        debuffs.Remove("spin");
        asdf.Add(8);

    }

}
