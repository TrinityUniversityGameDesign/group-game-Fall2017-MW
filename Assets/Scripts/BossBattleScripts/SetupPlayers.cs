using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPlayers : MonoBehaviour {
    public GameObject player;


	// Use this for initialization
	void Start () {

       int numPlayers =  GlobalControl.NumPlayers;
        if (numPlayers == 0)
        {
            GlobalControl.AddPlayer(1);
            GlobalControl.AddPlayer(2);
            GameObject Boss = GameObject.Find("Boss");
            Boss.GetComponent<knifeThrow>().playerNum = 1;
            GameObject.Find("magic_charcoal").GetComponent<targetFairy>().num = 1;
            GameObject.Find("Meat-Mallet-icon").GetComponent<mallet_time>().num = 1;
            Boss.GetComponent<BossHealth>().numPlayers = 1;


            GameObject ply = Instantiate(player);
            ply.GetComponent<PlayerControlBossBattle>().num = 2;
            ply.GetComponent<PlayerShootFood>().playerNum = 2;
        }
        else 
       for(int x = 1; x <= numPlayers; x++)
        {
            if (PlayerState.playerType[x] == PlayerType.CHEF)
            {
                GameObject Boss = GameObject.Find("Boss");
                Boss.GetComponent<knifeThrow>().playerNum = x;
                GameObject.Find("magic_charcoal").GetComponent<targetFairy>().num = x;
                GameObject.Find("Meat-Mallet-icon").GetComponent<mallet_time>().num = x;
                Boss.GetComponent<BossHealth>().numPlayers = numPlayers -1;
            } else
            {
                GameObject ply = Instantiate(player);
                ply.GetComponent<PlayerControlBossBattle>().num = x;
                ply.GetComponent<PlayerShootFood>().playerNum = x;
            }
        } 
		
	}
	
	// Update is called once per frame
	void Update () {
       
		
	}
}
