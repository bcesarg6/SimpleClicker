using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    Vector2 new_pointer_position;
    float x_diff;
    float y_diff;
    float new_x;
    float new_y;

    public void OnBeginDrag(PointerEventData eventData){
        x_diff = eventData.position.x - this.transform.position.x;
        y_diff = eventData.position.y - this.transform.position.y;
    }

    public void OnDrag(PointerEventData eventData){
        new_x = eventData.position.x - x_diff;
        new_y = eventData.position.y - y_diff;
        new_pointer_position = new Vector2(new_x, new_y);
        this.transform.position = new_pointer_position;
    }

    public void OnEndDrag(PointerEventData eventData){
    }

}