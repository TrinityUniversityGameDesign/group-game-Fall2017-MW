using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    // public string GameStart;

    public string startgame;

	// Use this for initialization

     void Start()
    {

    }
	public void StartGame () {
        print("Start Pushed");
        SceneManager.LoadScene(startgame);// (SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	// Update is called once per frame
	public void Quit () {
        print("Quit Pushed");
        Application.Quit();
	}
}
