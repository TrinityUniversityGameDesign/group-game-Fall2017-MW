using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndToMenu : MonoBehaviour {

    public string menu;

    void Update()
    {
        //   if (Input.anyKey)
        //  {
        //      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //  }
    }

    public void StartGame()
    {
        print("Start Pushed");
        SceneManager.LoadScene(menu);
    }

    // Update is called once per frame
    public void Quit()
    {
        print("Quit Pushed");
        Application.Quit();
    }
}

