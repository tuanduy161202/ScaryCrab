using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add1Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float deltaY;
    public float timeDestroy;
    Vector3 newPos;
    Vector3 oldPos;
    void Start()
    {
        newPos = transform.position + new Vector3(0, deltaY, 0);
        oldPos = transform.position + new Vector3(0, 0, 0);
        Destroy(gameObject, timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime*2);
    }
}
