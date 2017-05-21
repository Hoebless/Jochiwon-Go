using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

    bool selection;
    
    public bool IsThrow;

    Vector3 point;
    Vector3 touchoff;
    Vector3 throwimg;

	void Start ()
    {
        selection = false;
	}
	
    void OnMouseDown()
    {
        selection = true;
    }

    void OnMouseDrag()
    {
        if(selection && IsThrow)
        {
            point = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            point.z = gameObject.transform.position.z;
            gameObject.transform.position = point;
        }
    }
}
