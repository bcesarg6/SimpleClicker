using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PlusButtonScript : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler {
    public MainScript main_script;

    //When the object is created
    void Start() {

    }

    //Called when the pointer makes a click (just down)
    public void OnPointerDown(PointerEventData pointer_data) {
        this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, 0.5f);
    }

    //Function fired when a click (up and down) event happens
    public void OnPointerClick(PointerEventData pointer_data) {
        if (main_script.score >= main_script.plus_price) {
            main_script.score = main_script.score - main_script.plus_price;
            main_script.plus = main_script.plus + 1;
            main_script.plus_mod = main_script.plus_mod + 1;
            main_script.saveData("plus", main_script.plus);
            main_script.saveData("plus_mod", main_script.plus_mod);
            main_script.attScore();
            main_script.attPrices();
            main_script.attScore();
            main_script.attPlus();
            main_script.attShop();
        }
    }

    //Called when the pointer "ends" the click (realeses the button)
    public void OnPointerUp(PointerEventData pointer_data) {
        this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, 1f);
    }

}
