using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalItemScore : MonoBehaviour
{
    // Start is called before the first frame update
    Text scoreItem;
    void Start()
    {
        scoreItem = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreItem.text = "x " + ScoreItem.scoreValue;
    }
}
