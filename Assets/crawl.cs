using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crawl : MonoBehaviour
{
    public float accel;
    public Sprite tail;
    private bool seen;
    private GameObject seenob;
    // Start is called before the first frame update
    void Start()
    {
        seen = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localScale.x < 0)
        {
            var segs = transform.GetComponentsInChildren<Rigidbody2D>();
            foreach (Rigidbody2D rigd in segs)
            {
                rigd.AddForce(transform.right * accel, ForceMode2D.Force);
            }
        }
        else
        {
            var segs = transform.GetComponentsInChildren<Rigidbody2D>();
            foreach (Rigidbody2D rigd in segs)
            {
                rigd.AddForce(-transform.right * accel, ForceMode2D.Force);
            }
        }
        var dc = gameObject.GetComponent<BoxCollider2D>();
        var collide = Physics2D.OverlapBox(dc.bounds.center, dc.size, 0, LayerMask.GetMask("player", "dead"));
        if (collide != null)
        {
            seen = true;
            seenob = collide.gameObject;
        }
        else if (Random.Range(0, 9) == 0 && seen == true)
        {
            seen = false;
            seenob = null;
            var ps = transform.localScale;
            transform.localScale = new Vector3(-ps.x, ps.y, ps.z);
        }
        if (seen == true)
        {
            if (seenob.transform.position.x > transform.position.x)
            {
                var ps = transform.localScale;
                if (ps.x > 0)
                {
                    transform.localScale = new Vector3(-ps.x, ps.y, ps.z);
                }
            }
            if (seenob.transform.position.x < transform.position.x)
            {
                var ps = transform.localScale;
                if (ps.x < 0)
                {
                    transform.localScale = new Vector3(-ps.x, ps.y, ps.z);
                }
            }
        }
        if (transform.eulerAngles.z < 0)
        {
            GetComponent<Rigidbody2D>().AddTorque(1000);
        }
        else if (transform.eulerAngles.z < 0)
        {
            GetComponent<Rigidbody2D>().AddTorque(-1000);
        }
        var sg = transform.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer rend in sg)
        {
            if (rend.gameObject.transform.childCount <= 0 && transform.childCount > 1 && rend.tag != "acessory")
            {
                rend.sprite = tail;
                rend.GetComponent<Animator>().enabled = false;
            }
        }
        if (Random.Range(0, 100) == 0 && seen == false)
        {
            var ps = transform.localScale;
            transform.localScale = new Vector3(-ps.x, ps.y, ps.z);
        }
    }
}
