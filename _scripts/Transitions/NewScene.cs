using UnityEngine;
using System.Collections;

public class NewScene : MonoBehaviour {

	private GameObject warpTarget;

	// Use this for initialization
	void Start () {
		GameManager.canMove = true;
		warpTarget = GameObject.Find(GameManager.warpTarget);
		warpGo ();
	}
	
	// Update is called once per frame
	void Update () {

	}


	void warpGo(){
		GameObject.FindGameObjectWithTag("Player").transform.position = warpTarget.transform.position;
		Camera.main.transform.position = warpTarget.transform.position + new Vector3(0,0,-.5f);
	}
}
