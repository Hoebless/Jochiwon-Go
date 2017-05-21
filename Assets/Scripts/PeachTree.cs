using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeachTree : MonoBehaviour {

    GameObject target;
    Rigidbody2D rb2d;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0f;
    }
    
    void FixedUpdate()
    {
        CastRay();
        
        if (Input.GetMouseButtonDown(0))
        {
            if(target == this.gameObject)
            {
                rb2d.gravityScale = 1f;
            }
        }
    }
    
    void CastRay()
    {
        target = null;
        
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        
        if(hit.collider != null)
        {
            target = hit.collider.gameObject;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Background")
        {
            Destroy(this.gameObject);
        }
    }
}
