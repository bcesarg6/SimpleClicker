using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ShopDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public void OnBeginDrag(PointerEventData eventData){
    }

    public void OnDrag(PointerEventData eventData){
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData){
    }

}

/*
 Debug.Log("this.x = " +this.transform.localPosition.x.ToString());
        Debug.Log("this.y = " +this.transform.localPosition.y.ToString());
        Debug.Log("this.z = " +this.transform.localPosition.z.ToString());
        Debug.Log("mouse x = " + eventData.position.x.ToString());
        Debug.Log("mouse y = " + eventData.position.y.ToString());
Debug.Log("mouse new x  = " + pos.x.ToString());
        Debug.Log("mouse new y  = " + pos.y.ToString());
        Debug.Log("mouse new z  = " + pos.z.ToString());
        */