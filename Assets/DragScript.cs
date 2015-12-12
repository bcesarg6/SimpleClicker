using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    Vector2 new_pointer_position; //Vector that represents the relative pointer position
    float x_diff;                 //The x difference between the pointer and the object x
    float y_diff;                 //The y    ''        ''     ''   ''     ''  ''  ''    y
    float new_x;                  //The new x calculated
    float new_y;                  // ''  '' y     ''

    //When the object is created
    void Start() {
        this.gameObject.SetActive(false); //We set it to inactive so it does not appear on the screen
    }

    //Fired when drag starts. Gets the initial pointer position and calculates the difference
    public void OnBeginDrag(PointerEventData eventData) {
        x_diff = eventData.position.x - this.transform.position.x;
        y_diff = eventData.position.y - this.transform.position.y;
    }
    
    //During the drag sets the object position to the calculated position
    public void OnDrag(PointerEventData eventData) {
        new_x = eventData.position.x - x_diff;
        new_y = eventData.position.y - y_diff;
        new_pointer_position = new Vector2(new_x, new_y);
        this.transform.position = new_pointer_position;
    }

    //When the drag stops (fired before OnDrop)
    public void OnEndDrag(PointerEventData eventData) {
    }

}