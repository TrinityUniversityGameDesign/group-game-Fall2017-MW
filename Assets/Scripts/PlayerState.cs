using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType { APPLE, SAUSAGE, CARROT, STRAWBERRY, CHEF };

public static class PlayerState {

	public static PlayerType[] playerType;
	public static Color[] playerColor = new Color[5] {Color.white, Color.red, Color.cyan, new Color(.5f,0,.5f,1) , Color.green};

	public static int playersAlive;
	//e.g. playerType[1] = PlayerType.APPLE;
	//e.g. playerType[2] would return a PlayerType value

}
