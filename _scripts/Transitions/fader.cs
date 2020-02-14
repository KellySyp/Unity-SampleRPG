using UnityEngine;
using System.Collections;

public class fader : MonoBehaviour {

	Animator anim;
	bool fading = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	public IEnumerator FadeToClear(){
		fading = true;
		anim.SetTrigger ("fadeIn");

		while (fading) {
			yield return null;
		}
	}

	public IEnumerator FadeToBlack(){
		fading = true;
		anim.SetTrigger ("fadeOut");

		while (fading) {
			yield return null;
		}
	}

	void AnimationComplete(){
		fading = false;
	}

}
