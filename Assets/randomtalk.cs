using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomtalk : MonoBehaviour
{
    public string text;
    public talk talk;
    private string[] texts;
    // Start is called before the first frame update
    void Start()
    {
        texts = text.Split('/');
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        talk.t = texts[Random.Range(0, texts.Length)];
    }
}
