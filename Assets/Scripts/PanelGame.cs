using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelGame : MonoBehaviour {

    public string panelID; // Should be the same as ClickedObject.thisObject
    public GameObject textPF;
    private GameObject textGO;
    
    private void OnEnable() {
        
        // textGO = new GameObject("Panel Text");
        textGO = GameObject.Instantiate(textPF, Vector3.zero, Quaternion.identity, GameObject.Find("Text Stuff/Canvas").transform);
        // TextMeshProUGUI text = textGO.GetComponent<TextMeshProUGUI>();
        // text.text = "L";
    }

    private void OnDisable() {
        
        Transform.Destroy(textGO);

    }

}
