using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {


    public float Playerhealth = 5;

	public float timeDelay = 300;

	public Text win;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject && other.gameObject.layer == 11)
        {
            print("hit");
            Playerhealth -= 1;
            print(Playerhealth);
            if(Playerhealth <= 0)
            {
                BossHealth.deadPlayers += 1;
                gameObject.SetActive(false);
            }
        }
    }
}
