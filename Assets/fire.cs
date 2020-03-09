using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject fball;
    public float count;
    private float countn;
    // Start is called before the first frame update
    void Start()
    {
        countn = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dc = gameObject.GetComponent<BoxCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
        if (collide != null)
        {
            countn += 1 * Time.fixedDeltaTime;
            if(countn >= count)
            {
                if (GetComponent<SpriteRenderer>().flipX == true)
                {
                   var shoot = Instantiate(fball, transform.position - transform.right, transform.rotation);
                    shoot.transform.Rotate(0, 0, 180);
                }
                else
                {
                    Instantiate(fball, transform.position + transform.right, transform.rotation);
                }
                countn = 0;
            }
        }
    }
}
