using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marbles_Movement : MonoBehaviour
{
    public AnimationCurve parabolicCurve;
    public AnimationCurve curve2;
    public float speed = 1f;
    int goofyrandom;
    public float duration = 5f;
    private float startTime;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        float t = 2;
        Debug.Log(t);
        Vector2 position = new Vector3(t * speed, parabolicCurve.Evaluate(t), 0f);
        Vector2 position1 = new Vector3(t * -speed, parabolicCurve.Evaluate(t), 0f);
        Vector2 position2 = new Vector3(t * speed, curve2.Evaluate(t), 0f);
        Vector2 position3 = new Vector3(t * -speed, curve2.Evaluate(t), 0f);
        goofyrandom = Random.Range(1, 5);
        if (goofyrandom == 1)
        {
            rb.AddForce(position, ForceMode2D.Impulse);
        }
        else if (goofyrandom == 2)
        {
            rb.AddForce(position1, ForceMode2D.Impulse);
        }
        else if (goofyrandom == 3)
        {
            rb.AddForce(position2, ForceMode2D.Impulse);
        }
        else if (goofyrandom == 4)
        {
            rb.AddForce(position3, ForceMode2D.Impulse);
        }
        StartCoroutine(DestroyObject());
    }

    void Update()
    {
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
