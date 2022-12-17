using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public float timeDestroy;
    public float deltaYAdd1;
    public GameObject add1;
    public GameObject add2;
    public Sprite[] sprites;
    int id;

    public GameObject bubble;
    bool canThrought = true;
    float xMin = -0.11f;
    float xMax = 0.11f;
    float yMin = 0.3f;
    float yMax = 0.6f;
    public float minTime = 0.3f;
    public float maxTime = 0.8f;
    public int minCount = 1;
    public int maxCount = 2;
    void Start()
    {
        anim = GetComponent<Animator>();
        if (Random.Range(0, 3) == 0) id = 0;
        else id = 1;
      
        GetComponent<SpriteRenderer>().sprite = sprites[id];
    }

    // Update is called once per frame
    void Update()
    {
        if (canThrought) ThroughBubble();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "UnderBox")
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        canThrought=false;
        if (other.gameObject.tag == "Player")
        {
            AddScore(id);
            //anim.SetBool("disapear", true);
            Destroy(gameObject, timeDestroy);
            if (id==0)
            Instantiate(add1, transform.position + new Vector3(0, deltaYAdd1, 0), Quaternion.identity);
            else Instantiate(add2, transform.position + new Vector3(0, deltaYAdd1, 0), Quaternion.identity);

        }
    }
   
    void AddScore(int id)
    {
        ScoreItem.scoreValue = ScoreItem.scoreValue + id + 1;
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
