using UnityEngine;

public class ShopDrag : MonoBehaviour {

    public void move(GameObject obj){
        Vector2 mos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Debug.Log("mouse x" +Input.mousePosition.x.ToString());
        Debug.Log("mouse y" + Input.mousePosition.y.ToString());
        Debug.Log("x = " + obj.transform.localPosition.x.ToString());
        Debug.Log("y = " + obj.transform.localPosition.y.ToString());
        obj.transform.localPosition = mos;
    }
	
}
