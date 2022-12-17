using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //ScoreScript.scoreValue = 0;
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToLeaderBoard()
    {

    }
    public void changeBackGround()
    {
        SceneManager.LoadScene("ChangeBackGround");
    }
    public void SoundChange()
    {
        if (Sound.isPlaying) Sound.stop();
        else Sound.play();
    }
    public void playGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void quit()
    {
        Application.Quit();
    }
}
