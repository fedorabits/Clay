using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<FixedJoint2D>() == null)
        {
            transform.Rotate(0, 0, 45);
        }
        if(collision.gameObject.tag == "boss")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "dirt")
        {
            GetComponent<PolygonCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<ConstantForce2D>().relativeForce = new Vector2(0, 0);
            gameObject.tag = "Untagged";
            var fix = gameObject.AddComponent<FixedJoint2D>();
            fix.connectedBody = collision.rigidbody;
            fix.breakForce = 100;
        }
    }
}
