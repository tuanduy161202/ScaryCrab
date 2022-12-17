using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBackGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void classic()
    {
        SceneManager.LoadScene("Menu");
    }
    public void winter()
    {
        SceneManager.LoadScene("Menu2");
    }
    public void nether()
    {
        SceneManager.LoadScene("Menu3");
    }
}
