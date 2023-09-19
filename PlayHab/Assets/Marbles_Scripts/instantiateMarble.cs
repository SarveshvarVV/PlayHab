using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class instantiateMarble : MonoBehaviour
{
    private Vector2 originalPosition;
    public GameObject Circle;
    private int counter;

    IEnumerator waitingTime()
    {
        yield return new WaitForSeconds(3f);
        Circle = (GameObject)Instantiate(Circle, originalPosition, Quaternion.identity);
        counter++;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        if (counter >= 4)
        {
            yield break;
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        StartCoroutine(waitingTime());
    }
}
