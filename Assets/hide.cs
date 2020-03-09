using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide : MonoBehaviour
{
    public Sprite hides;
    public Sprite runs;
    public RuntimeAnimatorController running;
    private Rigidbody2D rigd;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rigd = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dc = gameObject.GetComponent<CapsuleCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
        if (collide != null)
        {
            float relpos = transform.position.x - collide.transform.position.x;
            if (collide.GetComponent<SpriteRenderer>().flipX == true)
            {
                if (relpos > 0)
                {
                    rend.flipX = true;
                    rend.sprite = runs;
                    GetComponent<Animator>().runtimeAnimatorController = running;
                    rigd.AddForce(Vector2.left * 10, ForceMode2D.Force);
                }
                else
                {
                    rend.sprite = hides;
                    GetComponent<Animator>().runtimeAnimatorController = null;
                }
            }
            else
            {
                if (relpos < 0)
                {
                    rend.flipX = false;
                    rend.sprite = runs;
                    GetComponent<Animator>().runtimeAnimatorController = running;
                    rigd.AddForce(Vector2.right * 10, ForceMode2D.Force);
                }
                else
                {
                    rend.sprite = hides;
                    GetComponent<Animator>().runtimeAnimatorController = null;
                }
            }
        }
    }
}
