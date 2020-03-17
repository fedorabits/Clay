using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatch : MonoBehaviour
{
    public GameObject babe;
    public GameObject shell;
    private bool go;
    public float count;
    private float init;
    private float shake;
    // Start is called before the first frame update
    void Start()
    {
        go = false;
        init = count;
        shake = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(go == true)
        {
            count -= 1 * Time.fixedDeltaTime;
        }
        if(count <= init / 2)
        {
            GetComponent<Rigidbody2D>().AddTorque(shake);
        }
        if(transform.eulerAngles.z >= 355)
        {
            shake = 1;
        }
        else if (transform.eulerAngles.z >= 5)
        {
            shake = -1;
        }
        if(count <= 0)
        {
            var hat = Instantiate(babe, transform.position, Quaternion.identity);
            var shl = Instantiate(shell, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if(GetComponent<SpriteRenderer>().color != Color.white)
            {
                if (GetComponent<SpriteRenderer>().color != Color.black)
                {
                    hat.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
                }
                shl.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            }
            else
            {
                hat.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0,1,0,1,1,1);
            }
        }
    }
    private void OnBecameVisible()
    {
        go = true;
    }
}
