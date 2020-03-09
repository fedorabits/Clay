using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talk : MonoBehaviour
{
    public string text;
    public Color textColor;
    public string t;
    private Color tc;
    public string response;
    public Color responseColor;
    public Text textTo;
    public GameObject parch;
    public string heldText;
    private float said;
    public BoxCollider2D bx;
    // Start is called before the first frame update
    void Start()
    {
        t = text;
        tc = textColor;
        said = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dc = gameObject.GetComponent<BoxCollider2D>();
        if(bx != null)
        {
            dc = bx;
        }
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
        if (collide != null)
        {
            if (said <= 1)
            {
                parch.GetComponent<SpriteRenderer>().enabled = true;
                textTo.text = text;
                textTo.color = textColor;
                if (collide.GetComponent<move>().holding == gameObject)
                {
                    textTo.text = heldText;
                    t = ">:(";
                }
                if (Input.GetKeyDown(KeyCode.C) == true && response != "")
                {
                    text = response;
                    textColor = responseColor;
                }
            }
            said += 1 * Time.fixedDeltaTime;
            if (GetComponent<die>() != null)
            {
                if (GetComponent<die>().hp <= 1)
                {
                    parch.GetComponent<SpriteRenderer>().enabled = false;
                    textTo.text = "";
                    text = t;
                    textColor = tc;
                    said = 0;
                }
            }
        }
        else if (said > 0)
        {
            parch.GetComponent<SpriteRenderer>().enabled = false;
            textTo.text = "";
            text = t;
            textColor = tc;
            said = 0;
        }
    }
}
