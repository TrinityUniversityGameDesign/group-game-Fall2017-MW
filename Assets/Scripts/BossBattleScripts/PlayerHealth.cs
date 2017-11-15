using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {


    public float Playerhealth;

    float dom;

	public float timeDelay = 300;

	public Text win;

    public Slider healthbar;

    // Use this for initialization
    void Start () {
        dom = Playerhealth;
        healthbar.value = healthLeft();
        BossHealth.deadPlayers = 0;
	}
	
	// Update is called once per frame
	void Update () {
        healthbar.value = healthLeft();
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject && other.gameObject.layer == 11 && BossHealth.Bosshealth > 0)
        {
            print("hit");
            Playerhealth -= 1;
            print(Playerhealth);
            if(Playerhealth <= 0)
            {
                BossHealth.deadPlayers += 1;
                healthbar.value = healthLeft();
                gameObject.SetActive(false);
            }
        }
    }


    float healthLeft()
    {
        return Playerhealth / dom;
    }

}
