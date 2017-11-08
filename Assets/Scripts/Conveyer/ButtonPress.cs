using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour {

	// Use this for initialization
	void Start () {
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

	}
	
	// Update is called once per frame
	void Update () {
		if(GlobalControl.GetButtonA(2))
        {
            SceneManager.LoadScene("MorganScene");
        }
	}

    public void TransitionScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
