﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConveyorBossControl : MonoBehaviour {
	public ConveyorController conveyor;
	public GameObject[] obPreFabs;
	public GameObject[] playerFabs;
	public float speed = 8;
	public int frameDelay = 100;
	private int BossPNum = 2;
	private Obstacle currentObstacle;
	private int frameCt = 0;
    public Text text;
	public List<GameObject> players;
	public System.Predicate<GameObject> isDisabled = IsEnabled;
	public Camera camera;
	private Bounds bounds;

	private static bool IsEnabled(GameObject obj)
	{
		return !obj.activeSelf;

	}

    // Use this for initialization
    void Start () {
		bounds = ConveyerPlayerMovement.OrthographicBounds(camera);
        int pTcount = 0;
		if (PlayerState.playerType == null) {
			GlobalControl.AddPlayer (1);
			GlobalControl.AddPlayer (2);
			PlayerState.playerType = new PlayerType[5] {PlayerType.APPLE,PlayerType.CHEF,PlayerType.APPLE,PlayerType.CARROT,PlayerType.SAUSAGE};
		}
		for (int i = 1; i <= GlobalControl.NumPlayers; i++) {
			if (PlayerState.playerType != null && PlayerState.playerType [i] == PlayerType.CHEF) {
				BossPNum = i;
				Debug.Log ("Boss number is " + i);
			} else {

				Debug.Log ((int)PlayerState.playerType [i]);
				var player = Instantiate (playerFabs [(int)PlayerState.playerType [i]]);
                pTcount++;
				//playerbounds = OrthographicBounds(transform.parent.GetComponentInChildren<Camera> ());
				//TODO: set player based on PlayerState
				player.transform.position += new Vector3 (i, 0, 0);
				player.GetComponent<ConveyerPlayerMovement> ().playerNum = i;
				player.GetComponent<ConveyerPlayerMovement> ().bounds = ConveyerPlayerMovement.OrthographicBounds(camera);
				player.GetComponent<AffectedByConveyor> ().conveyor = GetComponent<ConveyorController> ();
				players.Add (player);
			}

		}
		//
		//GlobalControl.AddPlayer (2);
		currentObstacle = Instantiate (obPreFabs[Random.Range(0,obPreFabs.Length)]).GetComponent<Obstacle>();
		currentObstacle.GetComponent<AffectedByConveyor> ().conveyor = conveyor;
		currentObstacle.transform.position = new Vector3(0, 7,0);

        StartCoroutine(GameTimer(60));
    }

    // Update is called once per frame
    void Update()
    {
		var x = GlobalControl.GetHorizontal(BossPNum) * 0.05f * speed;
		if (transform.position.x + x > bounds.max.x) {
			Debug.Log ("Clamping "+transform.position.x+" into "+bounds.max.x);
			x = Mathf.Clamp (x, int.MinValue,0);
		}
		else if(transform.position.x + x < bounds.min.x)
			x = Mathf.Clamp (x, 0, int.MaxValue);
		transform.position += new Vector3(x, 0, 0);
		
		if (players.TrueForAll (isDisabled)) {
            ChangeScene("End_Screen");
            Debug.Log ("Game Over");
		}
        frameCt++;
        if (currentObstacle != null)
        {

			currentObstacle.transform.position = transform.position;
            //Debug.Log ("Updating " + Input.GetButton ("X_P1"));
			if (GlobalControl.GetButtonA(BossPNum) || Input.GetKeyDown(KeyCode.Space))
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
				currentObstacle.transform.position = transform.position;
                frameCt = 0;
            }
        }
    }

    private IEnumerator GameTimer(float seconds)
    {
        for (float i = seconds; i >= 0; i -= 1f)
        {
            if (text != null)
             text.text = "Time Left: " + Mathf.Round(i) + "    ";
            if (i % 10 == 0)
                frameDelay = 7 * frameDelay / 8;
            yield return new WaitForSeconds(1);
        }
        ChangeScene("End_Screen");
    }

    public void ChangeScene (string levelName)
    {
		
		PlayerState.playersAlive = 0;
		foreach(GameObject p in players) {
			if (p.activeSelf)
				PlayerState.playersAlive++;
		}
        Debug.Log("Time Up");
        SceneManager.LoadScene(levelName);
    }


}
