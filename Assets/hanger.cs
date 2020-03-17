using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hanger : MonoBehaviour
{
    public float length;
    public Sprite fall;
    private Sprite norm;
    // Start is called before the first frame update
    void Start()
    {
        norm = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var thread = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        thread.GetComponent<SpriteRenderer>().size = new Vector2(0.1f, length);
        thread.GetComponent<HingeJoint2D>().anchor = new Vector2(0,thread.GetComponent<BoxCollider2D>().bounds.extents.y);
        GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, -thread.GetComponent<BoxCollider2D>().bounds.extents.y);
        var dc = gameObject.GetComponent<BoxCollider2D>();
        var collide = Physics2D.OverlapBox(dc.bounds.center, dc.size, 0, LayerMask.GetMask("player", "dead"));
        if (collide != null)
        {
            if (length <= 8)
            {
                length += 5 * Time.fixedDeltaTime;
                GetComponent<Rigidbody2D>().AddForce((collide.transform.position - transform.position).normalized * 2.5f, ForceMode2D.Impulse);
            }
            GetComponent<SpriteRenderer>().sprite = fall;
        }
        else if(length > 3)
        {
            length -= 1 * Time.fixedDeltaTime;
            GetComponent<SpriteRenderer>().sprite = norm;
        }
    }
}
