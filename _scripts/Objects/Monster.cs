using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	public string name;

	public int speed;
	public int moveType;
	public bool canMove;

	public bool inDialogue;

	//HP and MP will move to job class data later.
	public int CurrHP;
	public int MaxHP;

	public int CurrMP;
	public int MaxMP;

	public int level;
	public int EXP;
	//	public int jobClass;

	public Monster(string newName, int newSpeed, int newMoveType, int newCurrHP, int newMaxHP, int newCurrMP, int newMaxMP){
		name = newName;

		speed = newSpeed;
		moveType = newMoveType;
		canMove = true;

		inDialogue = false;

		CurrHP = newCurrHP;
		MaxHP = newMaxHP;

		CurrMP = newCurrMP;
		MaxMP = newMaxMP;
	

	}


}
