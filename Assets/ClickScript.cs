using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ClickScript : MonoBehaviour, IPointerClickHandler {
    public MainScript main_script;  //Our main script

    //Function fired when a click event happens
    public void OnPointerClick(PointerEventData pointer_data) {
        main_script.score = main_script.score + 1;
        main_script.attScore();
    }
}
