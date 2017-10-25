using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GlobalControl.GetButtonDownA(1)) Debug.Log("A pressed");
        if (GlobalControl.GetButtonDownB(1)) Debug.Log("B pressed");
        if (GlobalControl.GetButtonDownX(1)) Debug.Log("X pressed");
        if (GlobalControl.GetButtonDownY(1)) Debug.Log("Y pressed");
        if (GlobalControl.GetButtonDownStart(1)) Debug.Log("Start pressed");
        if (GlobalControl.GetButtonDownBack(1)) Debug.Log("Back pressed");
        if (GlobalControl.GetButtonDownRT(1)) Debug.Log("RT pressed");
        /*Debug.Log(GlobalControl.GetHorizontal(1));
        Debug.Log(GlobalControl.GetVertical(1));
        Debug.Log(GlobalControl.GetHorizontalAim(1));
        Debug.Log(GlobalControl.GetVerticalAim(1));*/
        
    }
}
