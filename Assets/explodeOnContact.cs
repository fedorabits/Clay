using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeOnContact : MonoBehaviour
{
    public GameObject boom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
