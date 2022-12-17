using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    static public bool isPause;
    public GameObject obj;
    static public GameObject Obj;
    public GameObject movement;
    static public GameObject mm;
    void Start()
    {
        isPause = false;
        Obj = obj;
        mm = movement;
        Obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isPause);
    }
    public void pressButton()
    {
        if (!isPause)
        {
            pauseGame();
        }
            
    }
    static public void pauseGame()
    {
        //pause.SetActive(true);
        //resume.SetActive(false);
        isPause = true;
        Time.timeScale = 0f;
        Obj.SetActive(true);
        mm.SetActive(false);
    }
    static public void resumeGame()
    {
        //pause.SetActive(false);
        //resume.SetActive(true);
        isPause = false;
        Time.timeScale = 1f;
        mm.SetActive(true);
        Obj.SetActive(false);
    }
}
