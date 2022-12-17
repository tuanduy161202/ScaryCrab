using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y + 7f, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Warning") Destroy(gameObject);
    }
}
