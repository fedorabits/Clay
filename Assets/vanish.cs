using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanish : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= 1*Time.fixedDeltaTime;
        if(time <= 0)
        {  
            Destroy(gameObject);
        }
    }
}
