using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseEnemy {

	public string name;

	public enum type
	{
		GRASS,
		FIRE,
		EARTH,
		ELECTRIC
	}

	public enum rarity
	{
		COMMON,
		UNCOMMON,
		RARE,
		SUPERRARE
	}

	public type enemyType;
	public rarity enemyRarity;

	public float baseHP;
	public float currHP;

	public int baseATK;
	public int curATK;
	public int baseDEF;
	public int curDEF;

}