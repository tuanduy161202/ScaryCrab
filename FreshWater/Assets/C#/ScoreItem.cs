using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreItem : MonoBehaviour
{
    // Start is called before the first frame update
    static public int scoreValue;
    Text scoreItem;
    void Start()
    {
        scoreValue = 0;
        scoreItem = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreItem.text = "x " + scoreValue;
    }
}
