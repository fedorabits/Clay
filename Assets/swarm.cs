using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swarm : MonoBehaviour
{
    private bool jump;
    public bool hold;
    public float accel;
    // Start is called before the first frame update
    void Start()
    {
        jump = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dc = gameObject.GetComponent<CapsuleCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
        var bait = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("dead"));
        var near = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("swarm"));
        if (collide != null)
        {
            var relpos = transform.position - collide.transform.position;
            if (relpos.x > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * accel, ForceMode2D.Force);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * accel, ForceMode2D.Force);
            }
            if (relpos.y < 0 && jump == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * accel/2, ForceMode2D.Impulse);
                jump = false;
            }
        }
        else if (bait != null)
        {
            var relpos = transform.position - bait.transform.position;
            if (relpos.x > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * accel, ForceMode2D.Force);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * accel, ForceMode2D.Force);
            }
            if (relpos.y < 0 && jump == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * accel/2, ForceMode2D.Impulse);
                jump = false;
            }
        }
        else if (near != null)
        {
            if (near.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                var relpos = transform.position - near.transform.position;
                if (relpos.x > 0)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.left * accel, ForceMode2D.Force);
                }
                else
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.right * accel, ForceMode2D.Force);
                }
                if (relpos.y < -1 && jump == true)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * accel/2, ForceMode2D.Impulse);
                    jump = false;
                }
            }
            else
            {
                var relpos = transform.position - near.transform.position;
                if (relpos.x > 0)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.right * accel, ForceMode2D.Force);
                }
                else
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.left * accel, ForceMode2D.Force);
                }
                if (relpos.y > 0 && jump == true)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * accel/2, ForceMode2D.Impulse);
                    jump = false;
                }
            }
        }
        if(hold == true && (GetComponent<die>().hp < 0.1f || GetComponent<HingeJoint2D>() == null))
        {
            transform.DetachChildren();
        }
        if (hold == true && transform.parent == null)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Rigidbody2D>().freezeRotation = true;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.position.y < transform.position.y - 0.5)
        {
            jump = true;
        }
        if (hold == true && collision.gameObject.layer == 16&& collision.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color&& collision.gameObject.GetComponent<HingeJoint2D>() == null)
        {
            var grip = collision.gameObject.AddComponent<HingeJoint2D>();
            grip.connectedBody = gameObject.GetComponent<Rigidbody2D>();
            grip.enableCollision = true;
            collision.rigidbody.freezeRotation = false;
            grip.breakForce = 500;
            collision.transform.parent = gameObject.transform;
        }
    }
}
