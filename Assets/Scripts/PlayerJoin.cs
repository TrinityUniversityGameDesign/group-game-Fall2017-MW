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
            playerBlocks[GlobalControl.AddPlayer(1)].GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
        }
        if (Input.GetButtonDown("A_P2") && hasJoined[2] == false)
        {
            hasJoined[2] = true;
            playerBlocks[GlobalControl.AddPlayer(2)].GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
        }
        if (Input.GetButtonDown("A_P3") && hasJoined[3] == false)
        {
            hasJoined[3] = true;
            playerBlocks[GlobalControl.AddPlayer(3)].GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
        }
        if (Input.GetButtonDown("A_P4") && hasJoined[4] == false)
        {
            hasJoined[4] = true;
            playerBlocks[GlobalControl.AddPlayer(4)].GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
        }

        if (GlobalControl.NumPlayers > 1)
        {
            startText.text = "Player 1 Press Start to Begin";
            if(GlobalControl.GetButtonDownStart(1))
            {
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
