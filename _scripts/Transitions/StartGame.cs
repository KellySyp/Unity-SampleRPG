using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour {

	//Audio clip to play when start button is pressed
	public AudioClip audioClip;


	//Fields to collect user input on start screen.
	public InputField playerName;
	public InputField food;

	//sets location to start player on next screen, and specifies what scene to load next.
	public int transportScene;
	public string warpTargetVal;

	//There is extra logic on start screen opposed to restart screen. 
	//If this is switched on, start screen logic will run.
	public bool startScreen = true;


	void Start(){
		//If start screen, name and food input fields are prepopulated.
		if(startScreen){
			playerName.text = GameManager.dialogueVariables["Name"];
			food.text = GameManager.dialogueVariables["Food"];
		}
	}

	//When start/restart buttons are pressed, Sound played and fade out animation begins
	public void pressStart(){
		//FadeOut.startFadeOut = true;
		AudioSource.PlayClipAtPoint(audioClip, transform.position);
		if(startScreen){
			//User input field values are stored as variables to be used throughout the game
			GameManager.dialogueVariables["Name"] = playerName.text;
			GameManager.dialogueVariables["Food"] = food.text;
		}
		GameManager.canMove = false;
		GameManager.warpTarget = "T Intro - House";
		fader sf = GameObject.FindGameObjectWithTag ("fader").GetComponent<fader> ();

		StartCoroutine(waitTime(2));

		//yield return StartCoroutine (sf.FadeToBlack ());


		//yield return StartCoroutine (sf.FadeToClear ());
	}

	IEnumerator waitTime(int time){
		yield return new WaitForSeconds(time);
		Destroy (GameObject.FindGameObjectWithTag ("music"));
		Application.LoadLevel(transportScene);
	}

}
