using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quest : MonoBehaviour
{
    public string text;
    public Color textColor;
    public GameObject objective;
    public talk said;
    public string thank;
    private bool done;
    public GameObject gift;
    public Vector3 given;
    public bool makeSolid;
    public bool Trans;
    private bool thanked;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
        thanked = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dc = gameObject.GetComponent<BoxCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
        if (collide != null && collide.gameObject.GetComponent<move>().holding == objective)
        {
            if (done == false)
            {
                said.text = text;
                said.textColor = textColor;
                Destroy(objective);
                if (Trans == true)
                {
                    gift.transform.position = transform.position + given;
                }
                else
                {
                    Instantiate(gift, transform.position + given, Quaternion.identity);
                }
                done = true;
            }
        }
        else
        {
            if (done == true && thanked == false)
            {
                said.t = thank;
                said.text = thank;
                if (makeSolid == true)
                {
                    GetComponent<PolygonCollider2D>().enabled = true;
                }
                else
                {
                    GetComponent<PolygonCollider2D>().enabled = false;
                }
                thanked = true;
            }
        }
    }
}
