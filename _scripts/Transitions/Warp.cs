using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public int transportScene;
	public string warpTargetVal;
	public bool changeMusic = false;

	IEnumerator OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			GameManager.canMove = false;
			GameManager.warpTarget = warpTargetVal;

			fader sf = GameObject.FindGameObjectWithTag ("fader").GetComponent<fader> ();

			yield return StartCoroutine (sf.FadeToBlack ());
			if (changeMusic) {
				Destroy (GameObject.FindGameObjectWithTag ("music"));
			}
			Application.LoadLevel (transportScene);

			yield return StartCoroutine (sf.FadeToClear ());
		}
	}
}
