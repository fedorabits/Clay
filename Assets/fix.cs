using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix : MonoBehaviour
{
    [TextArea]
    public string text;
    public int entry;
    public string[] entries;
    public read book;
    // Start is called before the first frame update
    void Start()
    {
        entries = text.Split('/');
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dc = gameObject.GetComponent<BoxCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
        if (collide != null && collide.GetComponent<move>().equipped == book.book)
        {
            int pgs = 0;
            foreach (string e in entries)
            {
                book.entries[entry + pgs] = entries[pgs];
                Destroy(gameObject);
                pgs += 1;
            }
        }
    }
}
