using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GlobalControl.GetButtonA(1))
        {
            SceneManager.LoadScene("MorganScene");
        }
	}

    public void TransitionScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
