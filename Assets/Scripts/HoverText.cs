using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class HoverText : MonoBehaviour {

    private void Update() {

        PointerEventData pED = new PointerEventData(EventSystem.current);
        pED.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pED, results);
        for(int i = 0; i < results.Count; i++) {
            if(results[i].gameObject == this.gameObject) {
                transform.GetChild(0).gameObject.SetActive(true);
            } else {
                results.RemoveAt(i);
                i--;
            }
        }
        if(results.Count == 0) {
            transform.GetChild(0).gameObject.SetActive(false);
        }

    }

    
    
}
