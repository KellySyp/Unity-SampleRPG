using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuController : MonoBehaviour {

	public GameObject[] menuPanels;
	public GameObject GoldSub;
	public GameObject HPSub;

	public GameObject buyList;
	public GameObject sellList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GoldSub.GetComponent<Text>().text = "Gold: " + GameManager.money;
		HPSub.GetComponent<Text>().text = "HP: " + Player.playerHealth+" / "+ Player.playerMaxHealth;
	}

	public void changeMenu(int panelNo){
		hideMenuAll ();

		//activate menu with name name
		menuPanels[panelNo].SetActive(true);

		//load properdata
	}

	public static void hideMenuAll(){
		//deactivate all menu objects
		GameObject[] menuArray = GameObject.FindGameObjectsWithTag ("menu");

		foreach (GameObject go in menuArray) {
			go.SetActive (false);
		}
	}

	public void showBuyList(){
		sellList.SetActive (false);
		buyList.SetActive (true);
	}

	public void showSellList(){
		buyList.SetActive (false);
		sellList.SetActive (true);
	}

	public void closeShop(){
		buyList.SetActive (false);
		sellList.SetActive (false);
		hideMenuAll ();
	}

	public void quitGame(){
		hideMenuAll ();
		Application.LoadLevel(4);
		Destroy(GameObject.FindGameObjectWithTag("music"));
	}
}
