using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game_Info {

	private static int money, markerNum, levelNum;
	private static string markerName;
	private static bool plasmaUnlocked, engineUnlocked, asteroidGone, shipAttackGone;

	public static int Money 
	{
		get 
		{
			return money;
		}
		set 
		{
			money = value;
		}
	}

	public static int MarkerNum 
	{
		get 
		{
			return markerNum;
		}
		set 
		{
			markerNum = value;
		}
	}

	public static int LevelNum 
	{
		get 
		{
			return levelNum;
		}
		set 
		{
			levelNum = value;
		}
	}

	public static bool PlasmaUnlocked 
	{
		get 
		{
			return plasmaUnlocked;
		}
		set 
		{
			plasmaUnlocked = value;
		}
	}

	public static bool EngineUnlocked 
	{
		get 
		{
			return engineUnlocked;
		}
		set 
		{
			engineUnlocked = value;
		}
	}

	public static bool AsteroidGone 
	{
		get 
		{
			return asteroidGone;
		}
		set 
		{
			asteroidGone = value;
		}
	}

	public static bool ShipAttackGone 
	{
		get 
		{
			return shipAttackGone;
		}
		set 
		{
			shipAttackGone = value;
		}
	}
}
