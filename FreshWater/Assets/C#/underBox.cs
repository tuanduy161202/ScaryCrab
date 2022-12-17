using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underBox : MonoBehaviour
{
    // Start is called before the first frame update
    //float time;
    public Rigidbody2D boxBody;
    public EdgeCollider2D jump;
    public GameObject bubble;
    public GameObject box;
    float xMin = -0.4f;
    float xMax = 0.4f;
    float yMin = 0.5f;
    float yMax = 1f;
    float minTime = 0.3f;
    float maxTime = 0.8f;
    int minCount = 2;
    int maxCount = 5;
    float timeThroughtBubble;

    float timeFreeze;
    bool freeze;

    bool canThrought = true;
    void Start()
    {
        freeze = false;
        timeThroughtBubble = Time.time;

    }
    // Update is called once per frame
    void Update()
    {
        if (PauseScript.isPause) return;
        if (canThrought && Time.time > timeThroughtBubble + 0.002f) ThroughBubble();
        CheckToFreeze();
    }
    void CheckToFreeze()
    {
        if (freeze && Time.time > timeFreeze)
        {
            boxBody.constraints = RigidbodyConstraints2D.FreezeAll;
            jump.enabled = true;
            Destroy(gameObject);

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.tag);
        if (other.tag == "Box" || other.tag == "Ground")
        {
            canThrought = false;
            ScoreScript.scoreValue++;
            freeze = true;
            timeFreeze = Time.time + 0.2f;
        }
        else if (other.tag == "Player")
        {
            Debug.Log("destroy");
            Destroy(other);

            //Instantiate(gameOver, Camera.main.transform.position, Quaternion.identity);

        }
    }
    void ThroughBubble()
    {
        int count = Random.Range(minCount, maxCount);
        for (int i = 0; i < count; i++)
        {
            Destroy(Instantiate(bubble, transform.position + new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0), Quaternion.identity), Random.Range(minTime, maxTime));
        }
        timeThroughtBubble = Time.time;
    }
}