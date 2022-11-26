using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Debuffs : MonoBehaviour {

    public Slider slider;
    public int seconds;
    public List<string> debuffs;
    public Image colorTint;

    private void Awake() {
        
        debuffs = new List<string> {"button", "nothing", "button", "color"};

    }

    private void Update() {

        slider.value += Time.deltaTime / seconds;

        if(slider.value >= 1) {

            if(PanelManager.panelGameGO.activeSelf) {
                return;
            }

            int r = Random.Range(0, debuffs.Count);
            if(debuffs[r] == "nothing") {
                Debug.Log("nothing");
            }
            if(debuffs[r] == "button") {
                Debug.Log("button");
                DebuffButton();
            }
            if(debuffs[r] == "color") {
                Debug.Log("color");
                DebuffColor();
            }

            slider.value = 0;

        }

    }

    void DebuffButton() {

        PanelGame.buttonsAmount += 1;
        if(PanelGame.buttonsAmount == 8) {
            debuffs.Remove("button");
            debuffs.Remove("button");
        }

    }

    void DebuffColor() {

        switch(Random.Range(0, 3)) {
            case 0 : 
                colorTint.color = new Color(0.7f, 0, 0.7f, 0.4f); // purple
            break;
            case 1 : 
                colorTint.color = new Color(0.7f, 0.7f, 0, 0.4f); // yellow
            break;
            case 2 : 
                colorTint.color = new Color(0.7f, 0.35f, 0, 0.4f); // orange
            break;
        }


    }

}
