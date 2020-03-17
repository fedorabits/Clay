using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topOnly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dc = gameObject.GetComponent<CapsuleCollider2D>();
        var collide = Physics2D.OverlapBox(dc.bounds.center, dc.size, 0);
        if (collide != null && collide.tag != "dirt" && collide.transform.position.y > transform.position.y + GetComponent<BoxCollider2D>().size.y/4)
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
