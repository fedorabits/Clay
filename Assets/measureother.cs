using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class measureother : MonoBehaviour
{
    public GameObject measured;
    private float md;
    // Start is called before the first frame update
    void Start()
    {
        md = measured.GetComponent<die>().hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (measured == null)
        {
            Destroy(gameObject);
        }
        var gethp = measured.GetComponent<die>().hp;
        if (gethp <= 0.05f)
        {
            Destroy(gameObject);
        }
        var size = gethp / md * 5;
        var sl = GetComponent<SpriteRenderer>().size;
        sl.x = size;
        gameObject.GetComponent<SpriteRenderer>().size = sl;
    }
    private void OnBecameVisible()
    {
        GetComponent<UnityEngine.Animations.PositionConstraint>().enabled = true;
    }
}
