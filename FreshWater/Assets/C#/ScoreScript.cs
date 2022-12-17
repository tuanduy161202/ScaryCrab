using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    static public int scoreValue;
    Text score;
    void Start()
    {
        scoreValue = 0;
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Score: " + scoreValue);
        score.text = "Score: " + scoreValue;
    }
}
