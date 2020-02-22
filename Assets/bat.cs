using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    private bool flight;
    public Sprite f1;
    public Sprite f2;
    private Sprite norm;
    private SpriteRenderer rendr;
    private float flighttime;
    private Rigidbody2D rigd;
    // Start is called before the first frame update
    void Start()
    {
        flight = false;
        rendr = GetComponent<SpriteRenderer>();
        norm = rendr.sprite;
        flighttime = 0;
        rigd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var pz = GameObject.FindGameObjectWithTag("Player").transform.position;
        pz.z = 0;
        var dz = gameObject.transform.position;
        if (pz.x >= dz.x - 1 && pz.x <= dz.x + 1)
        {
            if (pz.y < dz.y && pz.y >= dz.y - 15)
            {
                flighttime = 3;
                flight = true;
            }
        }
        if(flight == true)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.8f, 0.9f);
            rigd.gravityScale = 1;
            if(rigd.velocity.y <= 0)
            {
                rendr.sprite = f1;
            }
            else
            {
                rendr.sprite = f2;
            }
            if (rigd.velocity.y <= -5)
            {
                rigd.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                if (Random.Range(1, 10) > 5)
                {
                    rigd.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
                    rendr.flipX = true;
                }
                else
                {
                    rigd.AddForce(Vector2.right* 5, ForceMode2D.Impulse);
                    rendr.flipX = false;
                }
            }
            flighttime -= 1 * Time.fixedDeltaTime;
            if (flighttime <= 0)
            {
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1.5f);
                rigd.gravityScale = -1;
                rendr.sprite = norm;
                flight = false;
            }
        }
    }
}
