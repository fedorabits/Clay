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
    // Start is called before the first frame update
    void Start()
    {
        done = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dc = gameObject.GetComponent<BoxCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
        if (collide != null && collide.gameObject.GetComponent<move>().holding == objective)
        {
            said.text = text;
            said.textColor = textColor;
            Destroy(objective);
            done = true;
        }
        else
        {
            if (done == true)
            {
                said.text = thank;
            }
        }
    }
}
