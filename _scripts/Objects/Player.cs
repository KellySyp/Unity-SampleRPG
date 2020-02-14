using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string name;

	public int speed;
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

	public Item equippedWeapon;
	public Item equippedArmor;



	public Player(string newName, int newSpeed, int newCurrHP, int newMaxHP, int newCurrMP, int newMaxMP){
		name = newName;

		speed = newSpeed;
		canMove = true;

		inDialogue = false;

		CurrHP = newCurrHP;
		MaxHP = newMaxHP;

		CurrMP = newCurrMP;
		MaxMP = newMaxMP;


	}

	//Equip Weapon
	//Equip Armor
	//Gain HP
	//Lose HP
}
