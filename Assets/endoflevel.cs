using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endoflevel : MonoBehaviour
{
    public GameObject exit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dc = gameObject.GetComponent<BoxCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size / 2, 0, LayerMask.GetMask("player"));
        if (collide != null && Input.GetKeyDown(KeyCode.C) == true)
        {
            collide.transform.position = exit.transform.position;
        }

    }
}
