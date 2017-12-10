using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAfterTime : MonoBehaviour {
    private AudioSource aS;

	// Use this for initialization
	void Start () {
        aS = GetComponent<AudioSource>();
        StartCoroutine(startSong());
	}

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator startSong()
    {
        yield return new WaitForSeconds(50);
        aS.Play();
    }
}
