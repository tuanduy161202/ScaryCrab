using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    // Start is called before the first frame update
    Text finalScore;
    void Start()
    {
        finalScore = GetComponent<Text>();
        finalScore.text = "" + ScoreScript.scoreValue;
    }

    // Update is called once per frame
    void Update()
    {
        finalScore.text = "" + ScoreScript.scoreValue;
    }
}
