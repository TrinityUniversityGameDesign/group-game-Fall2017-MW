using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    private Timer StartingTime;
    private DropOff StartWinOff;


    public Text highscoreText;
    public string GameStart;
   


	// Use this for initialization

     void Start()
    {
        highscoreText.text = "Most Recent Time: " + PlayerPrefs.GetString("Most Recent Time");
    }
	public void StartGame () {
        SceneManager.LoadScene(GameStart);
        StartingTime.StartTime = 0f;
        StartWinOff.win = false;

        StartingTime.StartTime = Time.time;
        
	}
	
	// Update is called once per frame
	public void Quit () {
        Application.Quit();
	}
}
