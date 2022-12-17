using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    // Start is called before the first frame update
    public float xLimit;
    public float[] xPositions;
    public GameObject[] enemyPrefabs;
    //[System.Serializable]
    public GameObject warning;
    public Wave[] wave;
    public float currentTime;
    List<float> remainingPositions = new List<float>();
    int waveIndex;
    float xPos = 0;
    int rand;
    float disToCam;
    //float yCam
    void Start()
    {
        currentTime = 0;
        remainingPositions.AddRange(xPositions);
        disToCam = transform.position.y - Camera.main.transform.position.y;
    }
    void Box(float xPos)
    {
        int r = 0;
        if (Random.Range(0, 11) == 0) r = 1;
        Debug.Log("r = " + r);
        if (warning != null && enemyPrefabs[r].tag != "Item") Instantiate(warning, new Vector3(xPos, Camera.main.transform.position.y + 7f, 0), Quaternion.identity);
        Instantiate(enemyPrefabs[r], new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
    }
    void SelectWave()
    {
        remainingPositions = new List<float>();
        remainingPositions.AddRange(xPositions);
        waveIndex = Random.Range(0, wave.Length);
        currentTime = wave[waveIndex].delayTime;
        if (wave[waveIndex].spawnAmount == 1) xPos = Random.Range(-xLimit, xLimit);
        else if (wave[waveIndex].spawnAmount > 1)
        {
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            remainingPositions.RemoveAt(rand);
        }
        for (int i = 0; i < wave[waveIndex].spawnAmount; i++)
        {
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            Box(xPos);
            remainingPositions.RemoveAt(rand);
        }    
    }
    void ThroughOdd()
    {
        for (int i = 0; i < 3; i++)
        {
            Box(xPositions[2*i+1]);
        }
        currentTime = 3;
    }
    void ThroughEven()
    {
        for (int i = 0; i < 3; i++)
        {
            Box(xPositions[2 * i]);
        }
        currentTime = 3;
    }
    void Through7()
    {
        int posNotChoose = Random.Range(0, 8);
        for (int i = 0; i < 7; i++)
        {
            if (i == posNotChoose) continue;
            Box(xPositions[i]);
        }
        currentTime = 3;
    }
    // Update is called once per frame
    void Update()
    {
        if (PauseScript.isPause) return;
        //Debug.Log("BoxController.y = " + transform.position.y);
        //Debug.Log("Cam.y = " + Camera.main.transform.position.y);
        float new_y = disToCam + Camera.main.transform.position.y; 
        transform.position = new Vector3(0, new_y, 0);
        if (Player.StartMoving == true)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                int chose = Random.Range(0, 4);
                if (chose == 0)
                {
                    SelectWave();
                }
                else if (chose == 1) { ThroughEven(); }
                else if (chose == 2) { ThroughOdd(); }
                else { Through7(); }
            }
        }
    }
};
[System.Serializable]
public class Wave
{
    public float delayTime;
    public float spawnAmount;
};
