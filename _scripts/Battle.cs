using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Battle : MonoBehaviour {

	public bool listenKey = false;
	public GameObject actionPanel;
	public Button actionBtn;

	public int maxHealth = 50;
	public int health = 50;
	public int attack = 5;
	public int defense = 3;
	public int value = 20;

	public AudioClip hitClip;
	public AudioClip dieClip;

	bool isHit = false;

	Animator pAnim;

	// Use this for initialization
	void Start () {
		pAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
	}
	
	void Update(){
		if (listenKey && Input.GetKeyDown ("space")) {
			ActionBtnClicked ();
		}
		if (isHit) {
			StartCoroutine (hitBuffer ());
		}
	}

	//When the player enter's the object's field, the action button clears out previous actions and sets up action button
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			listenKey = true;
			actionBtn.onClick.RemoveAllListeners();
			actionBtn.onClick.AddListener(ActionBtnClicked);
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

	//What to do when the action button is clicked
	void ActionBtnClicked(){
		pAnim.SetTrigger("attackMode");
		if (!isHit) {
			transform.parent.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			isHit = true;
			health = health - Player.equippedWeapon.value;
			if (health <= 0) {
				AudioSource.PlayClipAtPoint (dieClip, transform.position);
				Destroy (transform.parent.gameObject);
				actionPanel.SetActive (false);
			} else {
				AudioSource.PlayClipAtPoint (hitClip, transform.position);
			}
		}
	}

	IEnumerator hitBuffer(){
		yield return new WaitForSeconds (0.5f);
		transform.parent.gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		isHit = false;
	}
}
