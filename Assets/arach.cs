using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arach : MonoBehaviour
{
    public float speed;
    private float s;
    public Sprite jump;
    private Sprite norm;
    // Start is called before the first frame update
    void Start()
    {
        s = speed;
        norm = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(-transform.up * 10, ForceMode2D.Force);
        GetComponent<Rigidbody2D>().AddForce(transform.right * speed, ForceMode2D.Force);
        var dc = gameObject.GetComponent<BoxCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
        if (collide != null && collide.transform.position.y < transform.position.y)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            speed = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = jump;
        }
        else
        {
            speed = s;
            GetComponent<Animator>().enabled = true;
            GetComponent<SpriteRenderer>().sprite = norm;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "dirt")
        {
            var hitRotation = Quaternion.FromToRotation(Vector3.up, collision.GetContact(0).normal);
            if (hitRotation.eulerAngles.x != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, hitRotation.eulerAngles.x);
            }
            else if (hitRotation.eulerAngles.y != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, hitRotation.eulerAngles.y);
            }
            else
            {
                transform.rotation = hitRotation;
            }
        }
        else
        {
            s *= -1;
        }
    }
}
