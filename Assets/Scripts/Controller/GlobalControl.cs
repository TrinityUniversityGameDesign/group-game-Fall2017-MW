using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalControl {

    #region public variables

    public static int NumPlayers;

    #endregion

    private static bool downRT=false; // Will need to be an array later

    #region public methods

    // 1 <= playerNum <= 4

    // For left joystick
    public static float GetHorizontal(int playerNum)
    {
        return Input.GetAxis("Horizontal_P1");
    }
    public static float GetVertical(int playerNum)
    {
        return Input.GetAxis("Vertical_P1");
    }

    // For right joystick
    public static float GetHorizontalAim(int playerNum)
    {
        return Input.GetAxis("Aim_Horizontal_P1");
    }
    public static float GetVerticalAim(int playerNum)
    {
        return Input.GetAxis("Aim_Vertical_P1");
    }

    // Get Button: every frame
    public static bool GetButtonA(int playerNum)
    {
        return Input.GetButton("A_P1");
    }
    public static bool GetButtonB(int playerNum)
    {
        return Input.GetButton("B_P1");
    }
    public static bool GetButtonX(int playerNum)
    {
        return Input.GetButton("X_P1");
    }
    public static bool GetButtonY(int playerNum)
    {
        return Input.GetButton("Y_P1");
    }
    public static bool GetButtonRT(int playerNum)
    {
        return (Input.GetAxis("RT_P1") > .5f);
    }

    // Get Button Down: the first frame only
    public static bool GetButtonDownA(int playerNum)
    {
        return Input.GetButtonDown("A_P1");
    }
    public static bool GetButtonDownB(int playerNum)
    {
        return Input.GetButtonDown("B_P1");
    }
    public static bool GetButtonDownX(int playerNum)
    {
        return Input.GetButtonDown("X_P1");
    }
    public static bool GetButtonDownY(int playerNum)
    {
        return Input.GetButtonDown("Y_P1");
    }
    public static bool GetButtonDownRT(int playerNum)
    {
        if(GetButtonRT(playerNum))
        {
            if (!downRT)
            {
                downRT = true;
                return true;
            }
            else return false;
        } else
        {
            downRT = false;
            return false;
        }
    }
    public static bool GetButtonDownStart(int playerNum)
    {
        return Input.GetButtonDown("Start_P1");
    }
    public static bool GetButtonDownBack(int playerNum)
    {
        return Input.GetButtonDown("Back_P1");
    }

    #endregion
}
