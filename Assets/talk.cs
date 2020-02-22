using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talk : MonoBehaviour
{
    public string text;
    public Color textColor;
    public Text textTo;
    public GameObject parch;
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
            parch.GetComponent<SpriteRenderer>().enabled = true;
            textTo.text = text;
            textTo.color = textColor;
        }
        else
        {
            parch.GetComponent<SpriteRenderer>().enabled = false;
            textTo.text = "";
        }
    }
}
