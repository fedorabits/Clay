using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dark : MonoBehaviour
{
    private SpriteRenderer rend;
    private BoxCollider2D dc;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        dc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("lite"));
        if (collide == null)
        {
            var rc = rend.color;
            rc.a += 0.1f;
            rend.color = rc;
        }
    }
}
