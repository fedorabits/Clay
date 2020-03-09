using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corva : MonoBehaviour
{
    private Rigidbody2D rigd;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rigd = GetComponent<Rigidbody2D>();
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dc = gameObject.GetComponent<BoxCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
        if (collide != null)
        {
            rigd.AddForce(-transform.right.normalized * 500, ForceMode2D.Force);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        var dc = gameObject.GetComponent<BoxCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
        if (collide != null)
        {
            if (collision.gameObject == collide.gameObject)
            {
                transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
            }
            else
            {
                Vector3 targ = collide.transform.position;
                targ.z = 0f;

                Vector3 objectPos = transform.position;
                targ.x = targ.x - objectPos.x;
                targ.y = targ.y - objectPos.y;

                float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));
            }
        }
        else
        {
            rigd.velocity = new Vector2(0, 0);
        }
    }
}
