using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachToParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<FixedJoint2D>().connectedBody = transform.parent.GetComponent<Rigidbody2D>();
        var thread = GetComponent<FixedJoint2D>().connectedBody.gameObject;
        GetComponent<FixedJoint2D>().connectedAnchor = new Vector2(0, -thread.GetComponent<BoxCollider2D>().bounds.extents.y);
        transform.position = thread.transform.position - thread.GetComponent<BoxCollider2D>().bounds.extents;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
