using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//A basic dialogue system
public class ChestDialogue : MonoBehaviour {

	//All we need is the ActionPanel to show/hide and what scrip[t this object uses.
	public GameObject actionPanel;
	public string filename = "oneLine";
	public GameObject controller;
	public int chestIndex = 0;
	public Animator anim;

	private bool listenKey = false;
	private bool inDialogue = false;
	private bool advanceFlag = false;
	//private int dialogueCounter = 0;

	void Start(){
		if (GameManager.chestsOpen [chestIndex]) {
			anim.SetBool ("isOpen", true);
		}
	}

	//When this function is triggered....
	void Update(){
		if (listenKey && Input.GetKeyDown ("space")) {
			if (!GameManager.chestsOpen [chestIndex] && !advanceFlag) {
				anim.SetTrigger ("isOpening");
				GameManager.chestsOpen [chestIndex] = true;
				StartCoroutine (Wait ());
			} else if (GameManager.chestsOpen [chestIndex] && !advanceFlag) {
				ActionBtnClicked();
				advanceFlag = true;
			} else {
				controller.GetComponent<DialogueController> ().label = "used";
				ActionBtnClicked();
			}
		}
	}

	//When the player enter's the object's field, the action button clears out previous actions and sets up action button
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			listenKey = true;
			actionPanel.SetActive(true);
			//DialogueManager.ActionButtonOn ();
		}
	}

	//When Player leaves obect's field, action panel disappears
	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			listenKey = false;
			actionPanel.SetActive(false);
		}
	}



	//We hide the action panel, send the script file to the manager, then start the dialogue.
	void ActionBtnClicked(){
		if (!inDialogue) {
			inDialogue = true;
			actionPanel.SetActive (false);
			controller.GetComponent<DialogueController> ().setDialogue (filename);
			//this.transform.parent.GetComponent<NPC_Movement> ().thisCanMove = false;
		}
		controller.GetComponent<DialogueController> ().advanceDialogue ();
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (0.4f);
		ActionBtnClicked ();
	}
}
