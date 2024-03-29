﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HotPotatoManager : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject carrotPrefab;
	public GameObject strawberryPrefab;
	public GameObject sausagePrefab;
	public GameObject applePrefab;
	public GameObject boomerangPrefab;
	public ArenaController arena;
	public Text countdownText;
	public AudioClip superSecretSong;

	public int playersLeft;
	public int countdown = 0;
    private int playerCountdown = 0;
	private int endTime;

	private Vector3[] positions = {
		Vector3.zero,
		new Vector3 (-5f, 5f, 0),
		new Vector3 (5f, 5f, 0),
		new Vector3 (-5f, -5f, 0),
		new Vector3 (5f, -5f, 0)
	};

	private AudioSource aud;
	private GameObject[] players = new GameObject[5];
	private bool[] isAlive = { false, false, false, false, false };
	private BoomerangController boomerang;

    public Animator PoofController;

	void Start () {

		aud = GetComponent<AudioSource> ();
		if (PlayerState.easterEgg) aud.clip = superSecretSong;

		for (int i=1; i<=GlobalControl.NumPlayers; ++i) {
			isAlive [i] = true;
			GameObject player = Instantiate (playerPrefab, Vector3.zero, Quaternion.identity);
			player.GetComponent<PlayerController> ().playerNum = i;
			players [i] = player;
			// in case of 10000 players
		}

		GameObject boomerangObject = Instantiate (boomerangPrefab, new Vector3(100f,100f,0f), Quaternion.identity);
		boomerang = boomerangObject.GetComponent<BoomerangController> ();
        boomerang.man = this;

		CheckNumPlayers();
		StartNewRound();
	}

	void FixedUpdate() {
		countdown++;
        playerCountdown++;
		if (countdown >= 1000) {
			if (countdown % 100 == 0) {
				aud.pitch += 0.05f;
			}
		}
		if (countdown == endTime) {
			Elimination ();
		}
        if (playerCountdown == 1000)
        {
            Elimination();
        }
	}

	void StartNewRound() {
		StartCoroutine (Countdown ());
		arena.SetupArena (playersLeft);
		countdown = 0;
		endTime = 2500 + Mathf.RoundToInt((Random.value * 100)) - 50;
		aud.Play ();
        aud.pitch = 1;
		bool noOwner = true;
		for (int i = 1; i != 5; i++) {
			if (isAlive [i]) {
				players [i].transform.position = positions[i];
			}
		}
		int rand = Random.Range (1, 4);
		while (!isAlive [rand]) {
			rand = Random.Range (1, 4);
		}
		players [rand].GetComponent<PlayerController> ().GetBoomerang (boomerang);

	}

    public void playerCatch()
    {
        playerCountdown = 0;
    }


    void Elimination() {
        int deadPlayerIndex = boomerang.lastHolder.playerNum;
		players[deadPlayerIndex].GetComponent<PlayerController>().isDead = true;
        players[deadPlayerIndex].GetComponent<SpriteRenderer>().color = Color.white;
        players[deadPlayerIndex].GetComponent<Animator>().SetBool("isDead", true);
		playerDeath (deadPlayerIndex);
        StartCoroutine(FinishElimination(deadPlayerIndex));
    }


	void playerDeath(int num) {
		GameObject deadFood = null;
		switch (PlayerState.playerType [num]) {

		case PlayerType.CARROT:
			deadFood = carrotPrefab;
			break;

		case PlayerType.STRAWBERRY:
			deadFood = strawberryPrefab;
			break;

		case PlayerType.SAUSAGE:
			deadFood = sausagePrefab;
			break;

		case PlayerType.APPLE:
			deadFood = applePrefab;
			break;

		default:
			Debug.Log ("bad death prefab");
			break;
		}
		players [num].GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		deadFood = Instantiate (deadFood, new Vector3(players [num].transform.position.x,players[num].transform.position.y, 0.5f), Quaternion.identity); //TODO: make this delete
		deadFood.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,600f));
	}

    IEnumerator FinishElimination(int deadPlayerIndex)
    {
		yield return new WaitForSeconds (.5f);
		Destroy (players [deadPlayerIndex]);
        yield return new WaitForSeconds(2.5f);
		isAlive [deadPlayerIndex] = false;

		int chefIndex = CheckNumPlayers ();

		if (playersLeft >= 2) {
			StartNewRound ();
		} else {
            Destroy(boomerang.gameObject);
            PlayerState.playerType[chefIndex] = PlayerType.CHEF;
			yield return new WaitForSeconds (1f);
            SceneManager.LoadScene("Start_Screen");
		}
	}

	//modify playersLeft, return index of the first chef alive
	int CheckNumPlayers() {
		int playerCount = 0;
		int chefIndex = 0;
		for (int i = 1; i != 5; i++) {
			if (isAlive [5-i]) {
				playerCount += 1;
				chefIndex = 5-i;
			}
		}
		playersLeft = playerCount;
		return chefIndex;
	}

	IEnumerator Countdown() {

		foreach (GameObject p in players) {
			if (p != null) {
				PlayerController c = p.GetComponent<PlayerController> ();
				c.rigid2d.velocity = Vector2.zero;
				c.hasControl = false;
			}	
		}

		countdownText.text = "3";
		yield return new WaitForSeconds (1f);
		countdownText.text = "2";
		yield return new WaitForSeconds (1f);
		countdownText.text = "1";
		yield return new WaitForSeconds (1f);
		countdownText.text = "GO!";


		foreach (GameObject p in players) {
			if (p != null) {
				PlayerController c = p.GetComponent<PlayerController> ();

				c.hasControl = true;
			}	
		}

		yield return new WaitForSeconds (0.5f);
		countdownText.text = "";
		playerCountdown = 0;

	}

}
