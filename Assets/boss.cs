using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public GameObject spike;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dc = gameObject.GetComponent<BoxCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
        if (collide != null)
        {
            if (gameObject.transform.rotation.eulerAngles.z > -90 || transform.rotation.eulerAngles.z < 90)
            {
                if (collide.transform.position.y > transform.position.y)
                {
                    if (Random.Range(0, 15) == 0)
                    {
                        var fire = Instantiate(spike, transform.position + (transform.up * 2), transform.rotation);
                        fire.transform.Rotate(0, 0, 180);
                    }
                }
            }
            else if(transform.eulerAngles.z < -90 || transform.eulerAngles.z > 90)
            {
                if (collide.transform.position.y < transform.position.y)
                {
                    if (Random.Range(0, 15) == 0)
                    {
                        var fire = Instantiate(spike, transform.position + (transform.up*2), transform.rotation);
                        fire.transform.Rotate(0, 0, 180);
                    }
                }
            }
        }
    }
}
