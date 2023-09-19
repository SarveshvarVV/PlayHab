using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marbles_BowlShake : MonoBehaviour
{
    

    [SerializeField] Vector3 ogposition;
    public float shakeIntensity = 0.1f;
    public float shakeIntensity1 = 0.1f;

    public bool shaking;
    
    // Start is called before the first frame update
    void Start()
    {
        ogposition = new Vector3(0, -1.93f, 0);
        transform.position = ogposition;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        StartCoroutine(Shaking());
        
    }
    IEnumerator Shaking()
    {
        shaking = true;
        yield return new WaitForSeconds(2f);
        Vector3 randomOffset = new Vector3(Mathf.PerlinNoise(0, Time.time * 5f) - 1f, 0, 0) * shakeIntensity;
        //Vector3 randomOffsetx = new Vector3(0, Mathf.PerlinNoise(0, Time.time * 10f) - 0.5f, 0) * shakeIntensity1;
        // Apply the offset to the object's position
        gameObject.transform.position = ogposition + randomOffset;
    }
}
