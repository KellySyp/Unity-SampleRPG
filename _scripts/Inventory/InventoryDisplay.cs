using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class InventoryDisplay : MonoBehaviour {

	public GameObject itemBtnPrefab;
	public GameObject[] itemMenus;
	public UnityEngine.UI.Text weaponEquipped;
	public UnityEngine.UI.Text armorEquipped;

	void Start(){
		displayInventory ();
	}

	void Update(){
		if (InventoryController.refreshDisplay) {
			displayInventory ();
		}
	}

	public void displayInventory(){
		//Display Items
		int yOffset = 0 ;
		for (var i = 0; i < itemMenus.Length; i++) {
			foreach (Transform child in itemMenus[i].transform) {
				Destroy (child.gameObject);
			}
		}
		for (var i = 0; i < InventoryController.itemList.Count; i++) {
			int Index = i;
			int thisType = InventoryController.itemList[i].type;
			var newItemBtn = Instantiate(itemBtnPrefab, new Vector3(itemMenus[thisType].transform.position.x,itemMenus[thisType].transform.position.y - yOffset,0), Quaternion.identity) as GameObject;
			newItemBtn.transform.parent = itemMenus[thisType].transform;
			Button b = newItemBtn.GetComponent<Button> ();
			b.onClick.AddListener(() => InventoryController.useItemFromMenu(thisType, Index));
			//change name text
			GameObject newName = newItemBtn.transform.Find("name").gameObject;
			newName.GetComponent<Text> ().text = InventoryController.itemList[i].name;
			yOffset = yOffset +50;
		}

		//Display Weapons
		weaponEquipped.text = Player.equippedWeapon.name;
		//Display Armor
		armorEquipped.text = Player.equippedArmor.name;
		shopController.refreshShopDisplay = true;
		InventoryController.refreshDisplay = false;
	}
}
