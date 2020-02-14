using UnityEngine;
using System.Collections;

public class ChestCotroller : MonoBehaviour {
	public Animator anim;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if( anim.GetCurrentAnimatorStateInfo(0).IsName("open") && !GameManager.chestOpen){
			GameManager.chestOpen = true;
		}

		if (GameManager.chestOpen) {
			anim.SetBool ("isOpen", true);
		} else if (!GameManager.chestOpen) {
			anim.SetBool ("isOpen", false);
		}
			
		
	}


}
