using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class measure : MonoBehaviour
{
    public GameObject measured;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gethp = measured.GetComponent<move>().hp;
        var size = gethp / 10 * 5;
        var sl = GetComponent<SpriteRenderer>().size;
        sl.x = size;
        gameObject.GetComponent<SpriteRenderer>().size = sl;
    }
}
