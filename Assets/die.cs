using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public float hp;
    public GameObject death;
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
            if (collide.gameObject.GetComponent<move>().attack == true)
            {
                hp -= 2*Time.fixedDeltaTime;
            }
        }
        if(hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(death, transform.position, Quaternion.identity);
        }
    }
}
