using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerJoin : MonoBehaviour {

    private bool[] hasJoined = {true, false, false, false, false }; //Corresponds to controller number
    private GameObject[] playerBlocks;
    private GameObject playerBlockPrefab;
    public Text startText;

    // Use this for initialization
    void Start () {
        PlayerState.easterEgg = false;
        GlobalControl.NumPlayers = 0;
        playerBlockPrefab = Resources.Load<GameObject>("Prefabs/playerBlock");
        playerBlocks = new GameObject[5];
        playerBlocks[1] = Instantiate(playerBlockPrefab, new Vector3(-6,-3,0), Quaternion.identity);
        playerBlocks[2] = Instantiate(playerBlockPrefab, new Vector3(-2, -3, 0), Quaternion.identity);
        playerBlocks[3] = Instantiate(playerBlockPrefab, new Vector3(2, -3, 0), Quaternion.identity);
        playerBlocks[4] = Instantiate(playerBlockPrefab, new Vector3(6, -3, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("A_P1") && hasJoined[1] == false)
        {
            hasJoined[1] = true;
			GlobalControl.AddPlayer (1);
			playerBlocks [GlobalControl.NumPlayers].GetComponent<SpriteRenderer> ().color = PlayerState.playerColor [GlobalControl.NumPlayers];
        }
        if (Input.GetButtonDown("A_P2") && hasJoined[2] == false)
        {
            hasJoined[2] = true;
			GlobalControl.AddPlayer (2);
			playerBlocks[GlobalControl.NumPlayers].GetComponent<SpriteRenderer>().color = PlayerState.playerColor [GlobalControl.NumPlayers];
        }
        if (Input.GetButtonDown("A_P3") && hasJoined[3] == false)
        {
            hasJoined[3] = true;
			GlobalControl.AddPlayer (3);
			playerBlocks[GlobalControl.NumPlayers].GetComponent<SpriteRenderer>().color = PlayerState.playerColor [GlobalControl.NumPlayers];
        }
        if (Input.GetButtonDown("A_P4") && hasJoined[4] == false)
        {
            hasJoined[4] = true;
			GlobalControl.AddPlayer (4);
			playerBlocks[GlobalControl.NumPlayers].GetComponent<SpriteRenderer>().color = PlayerState.playerColor [GlobalControl.NumPlayers];
        }

        if (GlobalControl.NumPlayers > 1)
        {
            startText.text = "Player 1 Press Start";
            if(GlobalControl.GetButtonDownStart(1))
            {
                PlayerState.playerType = new PlayerType[5];
                PlayerState.playerType[1] = PlayerType.APPLE;
                PlayerState.playerType[2] = PlayerType.CARROT;
                PlayerState.playerType[3] = PlayerType.SAUSAGE;
                PlayerState.playerType[4] = PlayerType.STRAWBERRY;
                SceneManager.LoadScene("HotPotato");
            }
			if(GlobalControl.GetButtonDownBack(1))
			{
				PlayerState.easterEgg = true;
				PlayerState.playerType = new PlayerType[5];
				PlayerState.playerType[1] = PlayerType.APPLE;
				PlayerState.playerType[2] = PlayerType.CARROT;
				PlayerState.playerType[3] = PlayerType.SAUSAGE;
				PlayerState.playerType[4] = PlayerType.STRAWBERRY;
				SceneManager.LoadScene("HotPotato");
			}
        }
    }
}
