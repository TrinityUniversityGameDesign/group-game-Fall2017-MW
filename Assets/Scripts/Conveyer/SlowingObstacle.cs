using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingObstacle : MonoBehaviour {

    public Obstacle baseObs;
    public void handleCollision(ConveyerPlayerMovement player)
    {
        player.mvSpeed = player.baseSpeed / 10;
        StartCoroutine(player.ObstacleTimer(player.stun));
        player.source.PlayOneShot(player.stunEffect, 1);
    }
	// Use this for initialization
	void Start () {
        baseObs = GetComponent<Obstacle>();
        if (baseObs != null)
            baseObs.onCollide += handleCollision;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
