using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void restart(){
		Destroy (GameObject.FindGameObjectWithTag ("music"));
		Application.LoadLevel(0);
	}
}
