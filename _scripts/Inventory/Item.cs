using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {


	public string name;
	public int type;
	public int value;
	public int cost;
	public int sell;
	public string description;

	public Item(string newName, int newType, int newValue, int newCost, int newSell, string newDescription){
		name = newName;
		type = newType;
		value = newValue;
		cost = newCost;
		sell = newSell;
		description = newDescription;
	}

	public static void useItem(int val){
		Player.playerHealth = Player.playerHealth + val;
		if (Player.playerHealth > Player.playerMaxHealth) {
			Player.playerHealth = Player.playerMaxHealth;
		}
	}
}
