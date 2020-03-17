using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dc = gameObject.GetComponent<BoxCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0);
        if(collide != null && collide.attachedRigidbody != null && collide.gameObject.layer != 14 && collide.isTrigger == false)
        {
            collide.attachedRigidbody.velocity /= 2;
        }
    }
}
