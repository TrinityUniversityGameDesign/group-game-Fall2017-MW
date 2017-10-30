using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GlobalControl.NumPlayers >= 1)
        {
            if(GlobalControl.GetButtonDownA(1)) Debug.Log("A1 pressed");
            else if(GlobalControl.GetButtonDownRT(1)) Debug.Log("RT1 pressed");
        }
        if(GlobalControl.NumPlayers >= 2)
        {
            if (GlobalControl.GetButtonDownA(2)) Debug.Log("A2 pressed");
            else if (GlobalControl.GetButtonDownRT(2)) Debug.Log("RT2 pressed");
        }
        if (GlobalControl.NumPlayers >= 3)
        {
            if (GlobalControl.GetButtonDownA(3)) Debug.Log("A3 pressed");
            else if (GlobalControl.GetButtonDownRT(3)) Debug.Log("RT3 pressed");
        }
        if (GlobalControl.NumPlayers >= 4)
        {
            if (GlobalControl.GetButtonDownA(4)) Debug.Log("A4 pressed");
            else if (GlobalControl.GetButtonDownRT(4)) Debug.Log("RT4 pressed");
        }
        /*if (GlobalControl.GetButtonDownA(1)) Debug.Log("A1 pressed");
        if (GlobalControl.GetButtonDownA(2)) Debug.Log("A2 pressed");
        if (GlobalControl.GetButtonDownX(1)) Debug.Log("X pressed");
        if (GlobalControl.GetButtonDownY(1)) Debug.Log("Y pressed");
        if (GlobalControl.GetButtonDownStart(1)) Debug.Log("Start pressed");
        if (GlobalControl.GetButtonDownBack(1)) Debug.Log("Back pressed");
        if (GlobalControl.GetButtonDownRT(1)) Debug.Log("RT pressed");*/
        /*Debug.Log(GlobalControl.GetHorizontal(1));
        Debug.Log(GlobalControl.GetVertical(1));
        Debug.Log(GlobalControl.GetHorizontalAim(1));
        Debug.Log(GlobalControl.GetVerticalAim(1));*/

    }
}
