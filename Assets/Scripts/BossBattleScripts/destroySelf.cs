using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(death());	
	}

    IEnumerator death()
    {

        yield return new WaitForSeconds(1);
        Destroy(this);
    }

}
