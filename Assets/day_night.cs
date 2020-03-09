using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class day_night : MonoBehaviour
{
    private bool rise;
    public float days;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var col = GetComponent<SpriteRenderer>().color;
        if (rise == false)
        {
            GetComponent<SpriteRenderer>().color = new Color(0,0,0,col.a-0.001f*Time.fixedDeltaTime);
            if (col.a <= 0)
            {
                rise = true;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(0,0,0,col.a +0.001f*Time.fixedDeltaTime);
            if(col.a >= 1)
            {
                rise = false;
                days += 1;
            }
        }
    }
}
