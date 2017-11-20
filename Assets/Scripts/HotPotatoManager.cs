using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HotPotatoManager : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject boomerangPrefab;

	public int countdown = 0;
    private int playerCountdown = 0;
	private int endTime;

	private AudioSource aud;
	private GameObject[] players = new GameObject[5];
	private bool[] isAlive = { false, false, false, false, false };
	private BoomerangController boomerang;

    public Animator PoofController;

	void Start () {

     //   poof = GetComponent< >
		aud = GetComponent<AudioSource> ();

		for (int i=1; i<=GlobalControl.NumPlayers; ++i) {
			isAlive [i] = true;
			GameObject player = Instantiate (playerPrefab, new Vector3 (Random.Range (-18f, 18f), Random.Range (-18f, 18f), 0), Quaternion.identity);
			player.GetComponent<PlayerController> ().playerNum = i;
			players [i] = player;
			// in case of 10000 players
		}

		GameObject boomerangObject = Instantiate (boomerangPrefab, Vector3.zero, Quaternion.identity);
		boomerang = boomerangObject.GetComponent<BoomerangController> ();
        boomerang.man = this;
		if (boomerang == null) {
			Debug.Log ("null 1");
		}
		players [1].GetComponent<PlayerController>().GetBoomerang (boomerang);
		endTime = 2000 + Mathf.RoundToInt((Random.value * 100)) - 50;
		//boomerang.lastHolder = players [1].GetComponent<PlayerController> ();
	}
	
	void Update () {
		

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
		countdown = 0;
		endTime = 2000 + Mathf.RoundToInt((Random.value * 100)) - 50;
		aud.Play ();
        aud.pitch = 1;
		for (int i = 1; i != 5; i++) {
			if (isAlive [i]) {
				players [i].GetComponent<PlayerController>().GetBoomerang (boomerang);
				break;
			}
		}
	}

    public void playerCatch()
    {
        playerCountdown = 0;
    }


    void Elimination() {
        int deadPlayerIndex = boomerang.lastHolder.playerNum;
        players[deadPlayerIndex].GetComponent<SpriteRenderer>().color = Color.white;
        players[deadPlayerIndex].GetComponent<Animator>().SetBool("isDead", true);
        StartCoroutine(FinishElimination(deadPlayerIndex));
    }


    IEnumerator FinishElimination(int deadPlayerIndex)
    {
        yield return new WaitForSeconds(1.5f);
		Destroy (players [deadPlayerIndex]);
		isAlive [deadPlayerIndex] = false;

		int playersLeft = 0;
		int chefIndex = 0;
		for (int i = 1; i != 5; i++) {
			if (isAlive [i]) {
				playersLeft += 1;
				chefIndex = i;
			}
		}

		if (playersLeft >= 2) {
			StartNewRound ();
		} else {
            Destroy(boomerang.gameObject);
            PlayerState.playerType[chefIndex] = PlayerType.CHEF;
            SceneManager.LoadScene("Start_Screen");
		}
	}
}
