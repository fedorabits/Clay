using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dc = gameObject.GetComponent<CapsuleCollider2D>();
        var collision = Physics2D.OverlapBox(transform.position, dc.size, 0);
        if(collision != null && collision.GetComponent<Rigidbody2D>() != null && collision.tag != "enemy")
        {
            Vector3 direction = (gameObject.transform.position - collision.transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * -100);
            if (collision.gameObject.layer == 9)
            {
                collision.GetComponent<move>().hp -= 0.1f;
            }
        }
    }
}
