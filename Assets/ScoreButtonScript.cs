using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ScoreButtonScript : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler {
    public MainScript main_script;  //Our main script
    public AudioSource coin_sound;  //Coin audio

    //Called when the pointer makes a click (just down) 
    public void OnPointerDown(PointerEventData pointer_data) {
		this.GetComponent<Animator>().Play("Pressed");
		print("tremeu");
        //this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, 0.5f);
    }

    //Function fired when a click (up and down) event happens
    public void OnPointerClick(PointerEventData pointer_data) {
        main_script.score = main_script.score + main_script.plus;
        main_script.attScore();
        coin_sound.Play();
    }

    //Called when the pointer "ends" the click (realeses the button)
    public void OnPointerUp(PointerEventData pointer_data) {
		this.GetComponent<Animator>().Play("Back");
        //this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, 1f);
    }
}
