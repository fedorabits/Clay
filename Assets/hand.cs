using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{
    public bool left;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameObject.GetComponent<Rigidbody2D>().velocity.x <= 1 && gameObject.GetComponent<Rigidbody2D>().velocity.x >= -1)
        {
            if (left == true) 
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.right * speed, ForceMode2D.Impulse);
                GetComponent<SpriteRenderer>().flipX = false;
                left = false;
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * speed, ForceMode2D.Impulse);
                GetComponent<SpriteRenderer>().flipX = true;
                left = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (left == false)
        {
            collision.rigidbody.AddForce(-transform.right*500);
        }
        else
        {
            collision.rigidbody.AddForce(transform.right * 500);
        }
    }
}
