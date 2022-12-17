using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void goToMenu()
    {
        SceneManager.LoadScene("Menu3");
    }
    public void quit()
    {
        Application.Quit();
    }
}
