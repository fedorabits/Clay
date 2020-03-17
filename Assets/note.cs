using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : MonoBehaviour
{
    private float dir;
    // Start is called before the first frame update
    void Start()
    {
        var cl = Random.ColorHSV();
        GetComponent<SpriteRenderer>().color = cl;
        dir = Random.Range(-2, 2);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(dir, 4));
        Color.RGBToHSV(GetComponent<SpriteRenderer>().color, out float h, out float s, out float v);
        GetComponent<AudioSource>().pitch =3 - (h/360)*3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dr = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(dr.r,dr.g,dr.b,dr.a- 0.01f);
        if(dr.a <= 0.01)
        {
            Destroy(gameObject);
        }
    }
}
