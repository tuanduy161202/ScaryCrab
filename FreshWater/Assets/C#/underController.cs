using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underController : MonoBehaviour
{
    public GameObject bubble;
    float xMin=-0.42f;
    float xMax=0.42f;
    float yMin=0.6f;
    float yMax=1;
    public float minTime=0.3f;
    public float maxTime=0.8f;
    public int minCount=1;
    public int maxCount=4;

    bool canThrought = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        canThrought = false;
    }

    void Update()
    {
        if (canThrought) ThroughBubble();
    }

    void ThroughBubble()
    {
        int count = Random.Range(minCount, maxCount);
        for (int i = 0; i < count; i++)
        {
            Destroy(Instantiate(bubble, transform.position + new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0), Quaternion.identity), Random.Range(minTime, maxTime));
        }
    }
}
