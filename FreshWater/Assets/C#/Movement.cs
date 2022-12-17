using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    static public float move;
    void Start()
    {
        move = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //move = 0f;
    }
    public void pressRight()
    {
        Debug.Log("Press Right");
        move = 1f;
    }
    public void pressLeft()
    {
        Debug.Log("Press Left");
        move = -1f;
    }
    public void exit()
    {
        move = 0;
    }

}
