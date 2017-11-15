using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType { APPLE, CHEF, SAUSAGE, CARROT, STRAWBERRY };

public static class PlayerState {

	public static PlayerType[] playerType;
	public static Color[] playerColor = new Color[5] {Color.white, Color.red, Color.blue, Color.yellow, Color.green};

	public static int PlayersAlive;
	//e.g. playerType[1] = PlayerType.APPLE;
	//e.g. playerType[2] would return a PlayerType value

}
