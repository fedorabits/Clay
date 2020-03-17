using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drift : MonoBehaviour
{
    private float dv;
    // Start is called before the first frame update
    void Start()
    {
        dv = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dv = Random.value-1;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(dv,-1), ForceMode2D.Force);
        if(GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (transform.parent != null)
        {
            GetComponent<SpriteRenderer>().color = transform.parent.GetComponent<SpriteRenderer>().color;
        }
    }
}
