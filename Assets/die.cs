using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public float hp;
    public GameObject death;
    public bool capsule;
    public bool colorAs;
    public bool drop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (capsule == true)
        {
            var dc = gameObject.GetComponent<CapsuleCollider2D>();
            var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
            if (collide != null)
            {
                if (collide.gameObject.GetComponent<move>().attack == true && collide.isTrigger == true)
                {
                    hp -= 2 * Time.fixedDeltaTime;
                }
            }
        }
        else
        {
            var dc = gameObject.GetComponent<BoxCollider2D>();
            var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
            if (collide != null)
            {
                if (collide.gameObject.GetComponent<move>().attack == true)
                {
                    hp -= 2 * Time.fixedDeltaTime;
                }
            }
        }
        if(hp <= 0)
        {
            Destroy(gameObject);
            var ded = Instantiate(death, transform.position, Quaternion.identity,transform.parent);
            if(drop == true)
            {
                ded.transform.parent = null;
            }
            if(colorAs == true)
            {
                ded.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            }
        }
    }
}
