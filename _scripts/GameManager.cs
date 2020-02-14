using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static bool canMove = true;
	public static bool advanceTime = true;
	public static bool isTalking = false;
	public static string warpTarget = "T Intro - House";
	public int level = 0;

	public static bool chestOpen = false;
	public static bool[] chestsOpen = new bool[2];
	public static bool[] haveKeyItem = new bool[1];
	public static int[] NPCManager = new int[2];

	public static string transitionTo = "startGame";

	public static Dictionary<string, string> dialogueVariables = new Dictionary<string, string> ();

	//Dialogue variables
	/*public static string Name = "Kelly";
	public static string Location = "New Jersey";
	public static string Food = "Bacon";*/

	// *** Battle Variables *** //
	// ************************ //

	/*public static int playerMaxHealth = 500;
	public static int CurrHP = 10;
	public static int playerAttack = 5;
	public static int playerDefense = 3;

	public static Item equippedWeapon;
	public static Item equippedArmor;*/

	public static int money = 500;

	public float time = 0.0f;
	public static int hr = 12;
	public static int min = 45;

	private bool showMenu = false;
	public GameObject mainMenu;


	UnityEngine.UI.Text goldHUD;
	UnityEngine.UI.Text hpHUD;
	UnityEngine.UI.Text timeHUD;

	// Use this for initialization
	void Awake () {
		//InitGame ();
		goldHUD = GameObject.Find("Gold").GetComponent<Text>();
		hpHUD = GameObject.Find("HP").GetComponent<Text>();

		dialogueVariables["Name"] = "Kelly";
		dialogueVariables ["Location"] = "New Jersey";
		dialogueVariables ["Food"] = "Bacon";
	}

	void Start(){
		//InvokeRepeating ("timeForward", 1.0f, 1.0f);
	}

	void InitGame(){
		if (Player.CurrHP <= 0) {
			Player.CurrHP = 100;
		}
		Application.LoadLevel(level);
	}

	void Update(){

		goldHUD.text = "Gold: " + money;
		hpHUD.text = "HP: " + Player.CurrHP+" / "+ Player.playerMaxHealth;

		if (Input.GetKeyDown ("r")) {
			if (!showMenu) {
				advanceTime = false;
				mainMenu.SetActive (true);
				showMenu = true;
				canMove = false;
			} else {
				menuController.hideMenuAll ();
				advanceTime = true;
				showMenu = false;
				canMove = true;
			}
		}
			
	}

	void timeForward(){
		if (advanceTime) {
			min++;
			if (min == 60) {
				hr++;
				min = 0;
			}
			if (hr == 13) {
				hr = 1;
			}
		}
	}
}
