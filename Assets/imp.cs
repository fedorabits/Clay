using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imp : MonoBehaviour
{
    public bool left;
    public float accel;
    private Rigidbody2D rigd;
    private SpriteRenderer rend;
    private bool jump;
    // Start is called before the first frame update
    void Start()
    {
        jump = true;
        rigd = GetComponent<Rigidbody2D>();
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (left == true)
        {
            rigd.AddForce(Vector2.left * accel);
            rend.flipX = false;
            if (Random.Range(0,50) == 0)
            {
                left = false;
            }
        }
        else
        {
            rigd.AddForce(Vector2.right * accel);
            rend.flipX = true;
            if (Random.Range(0, 50) == 0)
            {
                left = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var dz = gameObject.transform.position;
        if (collision.transform.position.y > dz.y - 1 && jump == true)
        {
            jump = false;
            rigd.AddForce(Vector2.up * accel * 25);
            if (left == true)
            {
                if (Random.Range(0, 10) == 0)
                {
                    left = false;
                }
            }
            else
            {
                if (Random.Range(0, 10) == 0)
                {
                    left = true;
                }
            }
        }
        else
        {
            jump = true;
        }
    }
}
