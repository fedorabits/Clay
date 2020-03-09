using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Events;

public class market : MonoBehaviour
{
    public GameObject currency;
    public List<GameObject> wares;
    public List<float> cost;
    private GameObject pay;
    public string a;
    public string b;
    [TextArea]
    public string header;
    public Text textTo;
    public GameObject parch;
    // Start is called before the first frame update
    void Start()
    {
        pay = PrefabUtility.GetNearestPrefabInstanceRoot(currency);
        int wn = 0;
        foreach (GameObject wr in wares)
        {
            header += string.Join("-",(wn+1).ToString() ,wr.name,cost[wn].ToString()+" "+currency.name + "s", "\n");
            wn += 1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float uc = 0;
        var dc = gameObject.GetComponent<CapsuleCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
        if (collide != null)
        {
            foreach (GameObject c in collide.GetComponent<move>().moneybag)
            {
                if(PrefabUtility.GetNearestPrefabInstanceRoot(c) == pay)
                {
                    uc += 1;
                }
            }
            textTo.text = header;
            parch.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            textTo.text = "";
            parch.GetComponent<SpriteRenderer>().enabled = false;
        }
        uc = 0;
        foreach (GameObject c in GameObject.Find("golem").GetComponent<move>().moneybag)
        {
            if (PrefabUtility.GetNearestPrefabInstanceRoot(c) == pay)
            {
                uc += 1;
            }
        }
        string ca = uc.ToString();
        GetComponent<talk>().t = string.Join(ca,a,b);
        GetComponent<talk>().text = GetComponent<talk>().t;
    }
    private void OnGUI()
    {
        float uc = 0;
        var dc = gameObject.GetComponent<CapsuleCollider2D>();
        var collide = Physics2D.OverlapBox(transform.position, dc.size, 0, LayerMask.GetMask("player"));
        if (Input.anyKeyDown == true && collide != null)
        {
            foreach (GameObject c in collide.GetComponent<move>().moneybag)
            {
                if (PrefabUtility.GetNearestPrefabInstanceRoot(c) == pay)
                {
                    uc += 1;
                }
            }
            Event e = Event.current;
            if (Event.current.isKey == true)
            {
                var np = (int)e.keyCode;
                np -= 49;
                if (np >= 0 && np <= wares.Count - 1)
                {
                    if (uc >= cost[np])
                    {
                        Instantiate(wares[np], transform.position, Quaternion.identity);
                        var r = new List<int>();
                        foreach(GameObject c in collide.GetComponent<move>().moneybag)
                        {
                            if (PrefabUtility.GetNearestPrefabInstanceRoot(c) == pay)
                            {
                                r.Add(collide.GetComponent<move>().moneybag.IndexOf(c));
                                if (r.Count ==cost[np])
                                {
                                   break;
                                }
                            }
                        }
                        foreach(int ra in r)
                        {
                            collide.GetComponent<move>().moneybag.RemoveAt(ra);
                        }
                    }
                }
            }
        }
    }
}
