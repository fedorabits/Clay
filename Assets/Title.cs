using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    private bool go;
    private Text words;
    // Start is called before the first frame update
    void Start()
    {
        go = false;
        words = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (go == true)
        {
            var tc = words.color;
            words.color = new Color(tc.r, tc.g, tc.b, tc.a - 0.1f * Time.fixedDeltaTime);
        }
    }
    private void OnBecameVisible()
    {
        go = true;
    }
}
