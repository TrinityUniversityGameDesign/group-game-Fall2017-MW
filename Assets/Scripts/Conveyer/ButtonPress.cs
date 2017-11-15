using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour {

    public string scene = "MorganScene";
	// Use this for initialization
	void Start () {
        /*
		//Testing only
		PlayerState.playerType = new PlayerType[5];

		GlobalControl.AddPlayer(1);
		PlayerState.playerType [1] = PlayerType.CHEF;

		GlobalControl.AddPlayer(2);
		PlayerState.playerType [2] = PlayerType.APPLE;

		GlobalControl.AddPlayer(3);
		PlayerState.playerType [3] = PlayerType.CARROT;

		GlobalControl.AddPlayer(4);
		PlayerState.playerType [4] = PlayerType.SAUSAGE;
        */
	}
	
	// Update is called once per frame
	void Update () {
		if(GlobalControl.GetButtonA(1))
        {
            SceneManager.LoadScene(scene);
        }
	}

    public void TransitionScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
