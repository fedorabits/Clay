using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swoop : MonoBehaviour
{
    public Sprite ll;
    public Sprite lr;
    public Sprite air;
    private SpriteRenderer rend;
    private Rigidbody2D rigd;
    private CapsuleCollider2D coll;
    public Vector2 fta;
    public GameObject note;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rigd = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        fta = new Vector2(0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        coll.size = rend.sprite.rect.size / 100;
        if(Random.Range(0,50) == 0 && rend.sprite != air)
        {
            if(rend.sprite == ll)
            {
                rend.sprite = lr;
            }
            else
            {
                rend.sprite = ll;
            }
        }
        var dc = gameObject.GetComponent<BoxCollider2D>();
        var collide = Physics2D.OverlapBox(dc.bounds.center, dc.size, 0, LayerMask.GetMask("player"));
        if (collide != null && rend.sprite != air && rigd.velocity.y == 0)
        {
            if (tag != "enemy")
            {
                if (collide.GetComponent<move>().attack == true)
                {
                    if (rend.sprite == lr)
                    {
                        if (collide.transform.position.x < transform.position.x)
                        {
                            rend.sprite = air;
                            rend.flipX = true;
                            fta += new Vector2(5, 15);
                        }
                    }
                    else if (collide.transform.position.x > transform.position.x)
                    {
                        rend.sprite = air;
                        fta += new Vector2(-5, 15);
                    }
                }
            }
            else
            {
                if (rend.sprite == ll)
                {
                    if (collide.transform.position.x < transform.position.x)
                    {
                        rend.sprite = air;
                        fta += new Vector2(-5, 15);
                    }
                }
                else if (collide.transform.position.x > transform.position.x)
                {
                    rend.sprite = air;
                    rend.flipX = true;
                    fta += new Vector2(5, 15);
                }
            }
        }
        if (rend.sprite == air)
        {
            fta += new Vector2(0, -rigd.velocity.normalized.y/2);
            rigd.AddForce(fta, ForceMode2D.Force);
        }
        else if (rigd.velocity.x != 0)
        {
            rend.flipX = false;
            fta = new Vector2(0, 0);
            rigd.velocity = fta;
        }
        if(Random.Range(0,100) == 0)
        {
            if (rend.sprite == ll)
            {
                rigd.AddForce(new Vector2(-2, 2), ForceMode2D.Impulse);
            }
            else
            {
                rigd.AddForce(new Vector2(2, 2), ForceMode2D.Impulse);
            }
            Instantiate(note, transform.position + new Vector3(0,1), Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            rend.sprite = ll;
        }
    }
}
