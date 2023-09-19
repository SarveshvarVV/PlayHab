using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleRotate : MonoBehaviour
{
    Rigidbody2D rb;
    int rands;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rands = Random.Range(-1, 2);
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(1, 0) * 0.01f, ForceMode2D.Impulse);
    }
}
