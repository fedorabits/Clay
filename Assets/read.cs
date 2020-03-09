using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class read : MonoBehaviour
{
    [TextArea]
    public string text;
    public List<string> entries;
    private int entry;
    public Text readTo;
    public GameObject book;
    // Start is called before the first frame update
    void Start()
    {
        entry = 0;
        entries = text.Split('/').ToList();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.V) == true && GameObject.Find("golem").GetComponent<move>().equipped == book)
        {
            if (GetComponent<SpriteRenderer>().enabled == false)
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (GetComponent<SpriteRenderer>().enabled == true)
        {
            readTo.text = entries[entry];
            if (Input.GetKeyDown(KeyCode.Comma) == true && entry - 1 >= 0)
            {
                entry -= 1;
            }
            if (Input.GetKeyDown(KeyCode.Period) == true && entry + 1 < entries.Count)
            {
                entry += 1;
            }
        }
        else
        {
            readTo.text = "";
            entry = 0;
        }
    }
}
