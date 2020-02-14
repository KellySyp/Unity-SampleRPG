using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	public string name;

	public int speed;
	public int moveType;
	public bool canMove;

	public bool inDialogue;
	public string diaScript;
	public int diaCounter;
	public int diaType;
	public string label;

	public NPC(string newName, int newSpeed, int newMoveType, string newScript, int newDiaType){
		name = newName;

		speed = newSpeed;
		moveType = newMoveType;
		canMove = true;

		inDialogue = false;
		diaScript = newScript;
		diaCounter = 0;
		diaType = newDiaType;
		label = "";
	}
		
}
