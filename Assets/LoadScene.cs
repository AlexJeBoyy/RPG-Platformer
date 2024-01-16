using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Lvl1Load()
    {
        SceneManager.LoadScene("Level1");

    }
    public void MenuLoad()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1.0f;
    }
    public void Lvl2Load()
    {
        SceneManager.LoadScene("Level2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
