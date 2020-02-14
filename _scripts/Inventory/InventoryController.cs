using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class InventoryController : MonoBehaviour {

	public static List<Item> itemList = new List<Item> ();
	public static Dictionary<string, Item> itemPresets = new Dictionary<string, Item> ();

	public static bool refreshDisplay = false;
	private static bool init = false;


	void Awake(){
		if (!init) {
			string[] itemLines = File.ReadAllLines ("Assets/_scripts/Inventory/itemPreset.txt");
			for (int i = 0; i < itemLines.Length;) {
				string newName = itemLines [i++];
				int newType = int.Parse (itemLines [i++]);
				int newValue = int.Parse (itemLines [i++]);
				int newCost = int.Parse (itemLines [i++]);
				int newSell = int.Parse (itemLines [i++]);
				string newDescription = itemLines [i++];
				var thisItem = new Item (newName, newType, newValue, newCost, newSell, newDescription);
				itemPresets [newName] = thisItem;
			}

			itemList.Add (itemPresets ["Potion"]);
			itemList.Add (itemPresets ["Potion"]);
			itemList.Add (itemPresets ["Potion"]);
			itemList.Add (itemPresets ["HiPotion"]);

			itemList.Add (itemPresets ["Metal Sword"]);
			Player.equippedWeapon = itemPresets ["Wooden Sword"];

			itemList.Add (itemPresets ["Leather Vest"]);
			Player.equippedArmor = itemPresets ["Chain Mail"];

			itemList.Add (itemPresets ["Locket"]);

			init = true;
		}
	}

	public static void useItemFromMenu(int Type, int Index){
		switch (Type) {
		case 0:
			useItem (Index);
			break;
		case 2:
			equipWeapon(Index);
			break;
		case 3:
			equipArmor (Index);
			break;
		default:
			Debug.Log (itemList [Index].name + " cannot be used here.");
			break;
		}
	}

	public static void useItem(int Index){
		Player.playerHealth = Player.playerHealth + itemList [Index].value;
		if (Player.playerHealth > Player.playerMaxHealth) {
			Player.playerHealth = Player.playerMaxHealth;
			}
		itemList.RemoveAt (Index);
		refreshDisplay = true;
	}

	public static void getItem(string name){
		itemList.Add (itemPresets [name]);
		refreshDisplay = true;
	}

	public static bool useKeyItem(string thisName){
		bool output = false;
		for (var i = 0; i < itemList.Count; i++) {
			if (itemList [i].name == thisName) {
				output = true;
				itemList.RemoveAt (i);
				refreshDisplay = true;
			}
		}
		return output; 
	}
		
	public static void equipWeapon(int Index){
		itemList.Add(itemPresets[Player.equippedWeapon.name]);
		Player.equippedWeapon = itemList [Index];
		itemList.RemoveAt (Index);
		refreshDisplay = true;
	}

	public static void equipArmor(int Index){
		itemList.Add(itemPresets[Player.equippedArmor.name]);
		Player.equippedArmor = itemList [Index];
		itemList.RemoveAt (Index);
		refreshDisplay = true;
	}
		
}
