using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

   // public string GameStart;
   


	// Use this for initialization

     void Start()
    {

    }
	public void StartGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	// Update is called once per frame
	public void Quit () {
        Application.Quit();
	}
}
