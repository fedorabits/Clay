using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    private SpriteRenderer rend;
    private CapsuleCollider2D dc;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        dc = GetComponent<CapsuleCollider2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        var collide = Physics2D.OverlapBox(transform.position, dc.size * 2, 0, LayerMask.GetMask("dark"));
        if (collide != null)
        {
            var rc = collide.gameObject.GetComponent<SpriteRenderer>().color;
            rc.a -= 0.5f;
            collide.gameObject.GetComponent<SpriteRenderer>().color = rc;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 13)
        {
            var rc = collision.gameObject.GetComponent<SpriteRenderer>().color;
            rc.a -= 0.1f;
            collision.gameObject.GetComponent<SpriteRenderer>().color = rc;
        }
    }
}
