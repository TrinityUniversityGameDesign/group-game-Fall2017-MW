using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectedByConveyor : MonoBehaviour {
	public bool isActive = true;
	public ConveyorController conveyor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive)
			transform.position += new Vector3 (0, conveyor.speed, 0);
	}
}
