using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class shopController : MonoBehaviour {

	public GameObject itemBtnPrefab;
	public GameObject buyMenu;
	public GameObject sellMenu;
	public GameObject pricePrefab;
	public UnityEngine.UI.Text merchantMsg;
	public static bool refreshShopDisplay = false;

	public string[] shopListItems;
	public string[] overrideInventory;

	private List<Item> itemShopList = new List<Item> ();

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if (refreshShopDisplay) {
			if (overrideInventory.Length > 0) {
				itemShopList.Clear ();
				for(int i =0; i< overrideInventory.Length; i++){
					itemShopList.Add(InventoryController.itemPresets[overrideInventory[i]]);
				}

			}else if (shopListItems.Length > 0) {
				Debug.Log ("No override Inventory");
				//for(int i =0; i< shopListItems.Length; i++){

					//itemShopList.Add(InventoryController.itemPresets[shopListItems[i]]);
				//}

			}

			displayBuyList ();
			displaySellList ();
			refreshShopDisplay = false;
		}
	}

	void displayBuyList(){
		//Display Items
		int yOffset = 0 ;
		foreach (Transform child in buyMenu.transform) {
			Destroy (child.gameObject);
		}
		for (var i = 0; i < itemShopList.Count; i++) {
			int Index = i;
			var newItemBtn = Instantiate(itemBtnPrefab, new Vector3(buyMenu.transform.position.x,buyMenu.transform.position.y - yOffset,0), Quaternion.identity) as GameObject;
			newItemBtn.transform.parent = buyMenu.transform;
			Button b = newItemBtn.GetComponent<Button> ();
			//b.onClick.RemoveAllListeners();
			b.onClick.AddListener(() => buyItem(Index));
			//change name text
			GameObject newName = newItemBtn.transform.Find("name").gameObject;
			newName.GetComponent<Text> ().text = itemShopList[i].name;

			var newKeyItemLabel = Instantiate(pricePrefab, new Vector3((buyMenu.transform.position.x + 500),buyMenu.transform.position.y - yOffset,0), Quaternion.identity) as GameObject;
			newKeyItemLabel.transform.parent = buyMenu.transform;

			//change name text

			newKeyItemLabel.GetComponent<Text> ().text = itemShopList[i].cost.ToString();
			yOffset = yOffset +50;
		}
	}

	void displaySellList(){
		//Display Items
		int yOffset = 0 ;
		foreach (Transform child in sellMenu.transform) {
			Destroy (child.gameObject);
		}
		for (var i = 0; i < InventoryController.itemList.Count; i++) {
			if (InventoryController.itemList [i].type != 1) {
				int Index = i;
				var newItemBtn = Instantiate (itemBtnPrefab, new Vector3 (sellMenu.transform.position.x, sellMenu.transform.position.y - yOffset, 0), Quaternion.identity) as GameObject;
				newItemBtn.transform.parent = sellMenu.transform;
				Button b = newItemBtn.GetComponent<Button> ();
				//b.onClick.RemoveAllListeners();
				b.onClick.AddListener (() => sellItem (Index));
				//change name text
				GameObject newName = newItemBtn.transform.Find ("name").gameObject;
				newName.GetComponent<Text> ().text = InventoryController.itemList [i].name;

				var newKeyItemLabel = Instantiate (pricePrefab, new Vector3 ((sellMenu.transform.position.x + 500), sellMenu.transform.position.y - yOffset, 0), Quaternion.identity) as GameObject;
				newKeyItemLabel.transform.parent = sellMenu.transform;

				//change name text

				newKeyItemLabel.GetComponent<Text> ().text = InventoryController.itemList [i].sell.ToString ();
				yOffset = yOffset + 50;
			}
		}
	}

	void buyItem(int Index){
		if (GameManager.money > itemShopList [Index].cost) {
			GameManager.money -= itemShopList [Index].cost;
			InventoryController.getItem (itemShopList [Index].name);
			InventoryController.refreshDisplay = true;
			merchantMsg.text = "Thanks for the purchase!";
		} else {
			merchantMsg.text = "Looks like you need more cash!";
		}
	}

	void sellItem(int Index){
		GameManager.money += InventoryController.itemList [Index].sell;
		InventoryController.itemList.RemoveAt (Index);
		displaySellList ();
		merchantMsg.text = "Thanks for the goods!";
		InventoryController.refreshDisplay = true;
	}
}
