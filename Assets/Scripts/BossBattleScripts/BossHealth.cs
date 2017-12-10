using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public Sprite healthImg;
    public int numPlayers;
    public float Bosshealth;
    float dom;
    

	public Text win;

	public float timeDelay = 300;

    public Slider healthbar;
    public static int deadPlayers = 0;

    private float ogHealth;
    public static bool isBossTwoThirdsHealth = false;
    public static bool isBossOneThird = false;

    // Use this for initialization
    void Start()
    {
        Bosshealth = Bosshealth * numPlayers;
        dom = Bosshealth;
        healthbar.value = healthLeft();
		win.GetComponent<Text> ().enabled = false;
        ogHealth = Bosshealth;
        isBossOneThird = false;
        isBossTwoThirdsHealth = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        healthbar.value = healthLeft();
        if(Bosshealth <= 0)
        {
			win.GetComponent<Text> ().enabled = true;
			win.text = "Players Win";
			timeDelay -= 1;
			if (timeDelay <= 0) {
				SceneManager.LoadScene ("food_win");
			}
        }
        if (deadPlayers >= numPlayers)
        {
            win.GetComponent<Text>().enabled = true;
            win.text = "Boss Win";
            timeDelay -= 1;
            if (timeDelay <= 0)
            {
                
                SceneManager.LoadScene("endScreen_boss");
            }
        }

        if(Bosshealth <= ogHealth * .66)
        {
            Debug.Log("True");
            isBossTwoThirdsHealth = true;
        }

        if(Bosshealth <= ogHealth * .40)
        {
            Debug.Log("true");
            isBossOneThird = true;
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject)
        {
            Bosshealth -= 1;
            print(Bosshealth);
        }
    }
    
    float healthLeft()
    {
        return Bosshealth / dom;
    }
}
