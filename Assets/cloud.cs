﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    private float go;
    // Start is called before the first frame update
    void Start()
    {
        go = 0;
    }

    // Update is called once per frame
    void Update()
    {
        go += 1 * Time.fixedDeltaTime;
        GetComponent<Rigidbody2D>().AddForce(Vector2.left *(Random.Range(0f,2f)-1));
    }
}
