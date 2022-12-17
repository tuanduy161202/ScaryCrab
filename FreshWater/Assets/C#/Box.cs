using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] box;
    int id;
    void Start()
    {
        id = Random.Range(0, 3);

        GetComponent<SpriteRenderer>().sprite = box[id];
    }

    // Update is called once per frame
    void Update()
    {
    }
}
