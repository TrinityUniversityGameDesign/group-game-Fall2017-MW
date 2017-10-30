using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalControl {

    #region public variables

    public static int NumPlayers = 0;

    #endregion

    private static bool[] downRT= {true, false, false, false, false };
    private static int[] players = {-1, 0, 0, 0, 0 };

    public static void AddPlayer(int controllerNumber)
    {
        NumPlayers += 1;
        players[NumPlayers] = controllerNumber;
        Debug.Log("Controller " + controllerNumber + " joined as player " + NumPlayers);
    }


    #region public methods

    // 1 <= playerNum <= 4

    // For left joystick
    public static float GetHorizontal(int playerNum)
    {
        return Input.GetAxis("Horizontal_P" + players[playerNum]);
    }
    public static float GetVertical(int playerNum)
    {
        return Input.GetAxis("Vertical_P" + players[playerNum]);
    }

    // For right joystick
    public static float GetHorizontalAim(int playerNum)
    {
        return Input.GetAxis("Aim_Horizontal_P" + players[playerNum]);
    }
    public static float GetVerticalAim(int playerNum)
    {
        return Input.GetAxis("Aim_Vertical_P" + players[playerNum]);
    }

    // Get Button: every frame
    public static bool GetButtonA(int playerNum)
    {
        return Input.GetButton("A_P" + players[playerNum]);
    }
    public static bool GetButtonB(int playerNum)
    {
        return Input.GetButton("B_P" + players[playerNum]);
    }
    public static bool GetButtonX(int playerNum)
    {
        return Input.GetButton("X_P" + players[playerNum]);
    }
    public static bool GetButtonY(int playerNum)
    {
        return Input.GetButton("Y_P" + players[playerNum]);
    }
    public static bool GetButtonRT(int playerNum)
    {
        return (Input.GetAxis("RT_P" + players[playerNum]) > .5f);
    }

    // Get Button Down: the first frame only
    public static bool GetButtonDownA(int playerNum)
    {
        return Input.GetButtonDown("A_P" + players[playerNum]);
    }
    public static bool GetButtonDownB(int playerNum)
    {
        return Input.GetButtonDown("B_P" + players[playerNum]);
    }
    public static bool GetButtonDownX(int playerNum)
    {
        return Input.GetButtonDown("X_P" + players[playerNum]);
    }
    public static bool GetButtonDownY(int playerNum)
    {
        return Input.GetButtonDown("Y_P" + players[playerNum]);
    }
    public static bool GetButtonDownRT(int playerNum)
    {
        if(GetButtonRT(playerNum))
        {
            if (!downRT[playerNum])
            {
                downRT[playerNum] = true;
                return true;
            }
            else return false;
        } else
        {
            downRT[playerNum] = false;
            return false;
        }
    }
    public static bool GetButtonDownStart(int playerNum)
    {
        return Input.GetButtonDown("Start_P" + players[playerNum]);
    }
    public static bool GetButtonDownBack(int playerNum)
    {
        return Input.GetButtonDown("Back_P" + players[playerNum]);
    }

    #endregion
}
