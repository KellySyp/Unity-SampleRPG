using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class PlayerController : MonoBehaviour {

	public static List<Item> PlayerList = new List<Item> ();
	public static Dictionary<string, Item> PlayerPresets = new Dictionary<string, Item> ();
	private static bool init = false;

	void Awake(){
		if (!init) {
			string[] playerLines = File.ReadAllLines ("Assets/_scripts/Objects/PlayerPreset.txt");
			for (int i = 0; i < playerLines.Length;) {
				string newName = playerLines [i++];
				int newSpeed = int.Parse (playerLines [i++]);
				int newCurrHP = int.Parse (playerLines [i++]);
				int newMaxHP = int.Parse (playerLines [i++]);
				int newCurrMP = int.Parse (playerLines [i++]);
				int newMaxMP = int.Parse (playerLines [i++]);
				var thisPlayer = new Player (newName, newSpeed, newCurrHP, newMaxHP, newCurrMP, newMaxMP);
				PlayerPresets [newName] = thisPlayer;
			}

			PlayerList.Add (PlayerPresets ["Hera"]);

			init = true;
		}
	}
		

}
