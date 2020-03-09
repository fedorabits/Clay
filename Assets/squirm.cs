using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squirm : MonoBehaviour
{
    private Rigidbody2D rigd;
    // Start is called before the first frame update
    void Start()
    {
        rigd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dc = gameObject.GetComponent<BoxCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
        if (collide != null)
        {
            if (Random.Range(1, 100) > 25)
            {
                if(collide.transform.position.x > transform.position.x)
                {
                    rigd.AddTorque(-300);
                }
                else
                {
                    rigd.AddTorque(300);
                }
            }
            else
            {
                if (collide.transform.position.x < transform.position.x)
                {
                    rigd.AddTorque(-300);
                }
                else
                {
                    rigd.AddTorque(300);
                }
            }
        }
        if(transform.childCount == 0 && name != "head")
        {
            var v = gameObject.AddComponent<vanish>();
            v.time = 1;
        }
    }
}
