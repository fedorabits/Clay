using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject key;
    public Sprite open;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == key)
        {
            collision.otherCollider.enabled = false;
            GetComponent<SpriteRenderer>().sprite = open;
            Destroy(key);
        }
    }
}
