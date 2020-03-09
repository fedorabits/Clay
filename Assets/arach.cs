using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arach : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(-transform.up * 9.81f, ForceMode2D.Force);
        GetComponent<Rigidbody2D>().AddForce(transform.right * speed, ForceMode2D.Force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "dirt")
        {
            var hitRotation = Quaternion.FromToRotation(Vector3.up, collision.GetContact(0).normal);
            if (hitRotation.eulerAngles.x != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, hitRotation.eulerAngles.x);
            }
            else if (hitRotation.eulerAngles.y != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, hitRotation.eulerAngles.y);
            }
            else
            {
                transform.rotation = hitRotation;
            }
        }
        else
        {
            speed *= -1;
        }
    }
}
