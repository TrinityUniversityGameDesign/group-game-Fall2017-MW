using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyObstacle : MonoBehaviour {

    public int pressesToFree = 5;
    public int frozenCount;
    public Obstacle baseObs;
    private ConveyerPlayerMovement p;
    public void handleCollision(ConveyerPlayerMovement player)
    {
        Debug.Log("Triggerd");
        p = player;
        transform.position = p.transform.position+new Vector3(0,0,-1);
        //player.mvSpeed = player.baseSpeed / 10;
        //StartCoroutine(player.ObstacleTimer(player.stun));
        // player.source.PlayOneShot(player.stunEffect, 1);
        p.canMove = false;
    }
    // Use this for initialization
    void Start () {
        frozenCount = pressesToFree;
        baseObs = GetComponent<Obstacle>();
        if (baseObs != null)
            baseObs.onCollide += handleCollision;
    }
	
	// Update is called once per frame
	void Update () {
        if (p != null && !p.canMove)
        {
			if (GlobalControl.GetButtonDownA (p.playerNum)) {
				GetComponent<Animator> ().SetBool ("Apressed", true);

				frozenCount--;
			} else {
				GetComponent<Animator> ().SetBool ("Apressed", false);
			}
				
            if (frozenCount <= 0)
            {
                
                p.canMove = true;
                GameObject.Destroy(gameObject);
            }
        }
	}
}
