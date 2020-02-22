using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float acceleration;
    public Sprite norm;
    private SpriteRenderer rend;
    private Rigidbody2D rigd;
    private bool IsLand;
    public RuntimeAnimatorController walk;
    public RuntimeAnimatorController punch;
    public RuntimeAnimatorController lift;
    public bool attack;
    public BoxCollider2D push;
    private float punchcount;
    public float hp;
    public GameObject corpse;
    public GameObject spawn;
    public Sprite sactive;
    public Sprite sdead;
    public Sprite duck;
    public Sprite dduck;
    private bool ducking;
    private RuntimeAnimatorController norms;
    public GameObject holding;
    public Sprite lifts;
    public Sprite deadlifts;
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        rigd = gameObject.GetComponent<Rigidbody2D>();
        norms = walk;
        punchcount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dc = gameObject.GetComponent<BoxCollider2D>();
        if (Input.GetKey(KeyCode.LeftArrow) == true&& ducking == false)
        {
            rigd.AddForce(-transform.right * acceleration);
            rend.flipX = true;
            GetComponent<Animator>().enabled = true;
            push.offset = new Vector2(-0.7293483f,0);
            GetComponent<AreaEffector2D>().forceMagnitude = -50;
        }
        else if (Input.GetKey(KeyCode.RightArrow) == true && ducking == false)
        {
            rigd.AddForce(transform.right * acceleration);
            rend.flipX = false;
            GetComponent<Animator>().enabled = true;
            push.offset = new Vector2(0.7293483f, 0);
            GetComponent<AreaEffector2D>().forceMagnitude = 50;
        }
        else if (attack == false)
        {
            GetComponent<Animator>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) == true&& IsLand == true && ducking == false)
        {
            rigd.AddForce(transform.up * acceleration * 45);
            IsLand = false;
        }
        var ladd = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("ladder"));
        if (Input.GetKey(KeyCode.UpArrow) == true && ladd == true && ducking == false)
        {
            rigd.AddForce(transform.up * acceleration*5);
            IsLand = false;
        }
        if (Input.GetKey(KeyCode.Z) == true && ducking == false&&attack == false)
        {
            GetComponent<Animator>().runtimeAnimatorController = punch;
            GetComponent<Animator>().enabled = true;
            attack = true;
            push.enabled = true;
            punchcount = 0.5f;
            if (holding != null)
            {
                holding.GetComponent<FixedJoint2D>().breakForce = 0;
                holding.GetComponent<FixedJoint2D>().enabled = false;
                if (rend.flipX == true)
                {
                    holding.GetComponent<Rigidbody2D>().AddForce(-transform.right * 1000, ForceMode2D.Force);
                }
                else
                {
                    holding.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000, ForceMode2D.Force);
                }
                holding.GetComponent<FixedJoint2D>().enabled = true;
                holding = null;
                walk = norms;
                rend.sprite = norm;
            }
        }
        else if(punchcount <= 0)
        {
            GetComponent<Animator>().runtimeAnimatorController = walk;
            attack = false;
            push.enabled = false;
        }
        if (attack == true)
        {
            punchcount -= 1 * Time.fixedDeltaTime;
        }
        if (hp <= 0 || Input.GetKeyDown(KeyCode.D) == true)
        {
            var ded = Instantiate(corpse, gameObject.transform.position, transform.rotation);
            ded.GetComponent<SpriteRenderer>().flipX = rend.flipX;
            transform.position = spawn.transform.position;
            transform.rotation = spawn.transform.rotation;
            hp = 10;
            if (ducking == true)
            {
                ded.GetComponent<SpriteRenderer>().sprite = dduck;
                ded.GetComponent<BoxCollider2D>().size = new Vector2(1.1f, 1);
            }
            if (holding != null)
            {
                holding.GetComponent<FixedJoint2D>().breakForce = 50;
                holding.GetComponent<FixedJoint2D>().connectedBody = ded.GetComponent<Rigidbody2D>();
                holding = null;
                ded.GetComponent<SpriteRenderer>().sprite = deadlifts;
            }
            walk = norms;
            rend.sprite = norm;
        }
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("spawn"));
        if (collide != null)
        {
            spawn.GetComponent<SpriteRenderer>().sprite = sdead;
            spawn = collide.gameObject;
            spawn.GetComponent<SpriteRenderer>().sprite = sactive;
        }
        if (Input.GetKey(KeyCode.DownArrow) == true && holding == null)
        {
            rend.sprite = duck;
            GetComponent<BoxCollider2D>().size = new Vector2(1.1f, 1);
            push.size = new Vector2(0.7660124f, 1);
            ducking = true;
        }
        else if (holding == null)
        {
            rend.sprite = norm;
            GetComponent<BoxCollider2D>().size = new Vector2(1.1f, 1.9f);
            push.size = new Vector2(0.7660124f, 1.9f);
            ducking = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsLand = true;
        if (collision.gameObject.tag == "enemy")
        {
            hp -= collision.gameObject.GetComponent<hurt>().harm;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && ducking == false && collision.gameObject.tag != "dirt" && holding == null && collision.transform.position.y > transform.position.y -1.5f)
        {
            collision.transform.position = new Vector3(transform.position.x, (transform.position.y+gameObject.GetComponent<BoxCollider2D>().size.y /2));
            var fix = collision.gameObject.AddComponent<FixedJoint2D>();
            fix.connectedBody = rigd;
            walk = lift;
            holding = collision.gameObject;
            rend.sprite = lifts;
        }
    }
}
