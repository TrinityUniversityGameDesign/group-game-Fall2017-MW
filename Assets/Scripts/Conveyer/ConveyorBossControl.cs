﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorBossControl : MonoBehaviour {
	public ConveyorController conveyor;
	public GameObject[] obPreFabs;
	public GameObject[] playerFabs;
	public float speed = 6;
	public int frameDelay = 100;
	private int BossPNum = 2;
	private Obstacle currentObstacle;
	private int frameCt = 0;
    public Text text;

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

		for (int i = 0; i < GlobalControl.NumPlayers; i++) {
			if (PlayerState.playerType [i + 1] == PlayerType.CHEF) {
				BossPNum = i;
			} else {
				var player = Instantiate (playerFabs [0]);
				player.transform.position += new Vector3 (i, 0, 0);
				player.GetComponent<ConveyerPlayerMovement> ().playerNum = i;
				player.GetComponent<AffectedByConveyor> ().conveyor = GetComponent<ConveyorController> ();
			}

		}
		//GlobalControl.AddPlayer (1);
		//GlobalControl.AddPlayer (2);
		currentObstacle = Instantiate (obPreFabs[Random.Range(0,obPreFabs.Length)]).GetComponent<Obstacle>();
		currentObstacle.GetComponent<AffectedByConveyor> ().conveyor = conveyor;
		currentObstacle.transform.position = new Vector3(0, 7,0);

        StartCoroutine(GameTimer(10));
    }

    // Update is called once per frame
    void Update()
    {
        frameCt++;
        if (currentObstacle != null)
        {

            currentObstacle.transform.position += new Vector3(GlobalControl.GetHorizontal(BossPNum) * 0.05f * speed, 0, 0);
            //Debug.Log ("Updating " + Input.GetButton ("X_P1"));
            if (Input.GetButtonDown("X_P1"))
            {
                Debug.Log("Pressed");
                currentObstacle.GetComponent<Obstacle>().setActive(conveyor);
                currentObstacle = null;
                frameCt = 0;

            }
        }
        else
        {
            if (frameCt > frameDelay)
            {
                currentObstacle = Instantiate(obPreFabs[Random.Range(0, obPreFabs.Length)]).GetComponent<Obstacle>();
                currentObstacle.GetComponent<AffectedByConveyor>().conveyor = conveyor;
                currentObstacle.transform.position = new Vector3(0, 7, 0);
                frameCt = 0;
            }
        }
    }

    private IEnumerator GameTimer(float seconds)
    {
        for (float i = seconds; i >= 0; i -= 1f)
        {
            text.text = "Time Left: " + Mathf.Round(i) + "    ";
            yield return new WaitForSeconds(1);
        }
        //END SCENE
    }
}
