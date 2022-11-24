using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Debuffs : MonoBehaviour {

    public Slider slider;
    public int seconds;
    public List<string> debuffs;

    private void Awake() {
        
        debuffs = new List<string> {"button", "nothing", "button"};

    }

    private void Update() {
        Debug.Log(PanelGame.buttonsAmount);

        slider.value += Time.deltaTime / seconds;

        if(slider.value >= 1) {

            if(PanelManager.panelGameGO.activeSelf) {
                return;
            }

            int r = Random.Range(0, debuffs.Count);
            if (debuffs[r] == "nothing") {
                Debug.Log("nothing");
            }
            if (debuffs[r] == "button") {
                Debug.Log("button");
                DebuffButton();
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

}
