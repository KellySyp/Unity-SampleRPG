using UnityEngine;
using System.Collections;

public class randomMusic : MonoBehaviour {

	public Object[] clipList;
	private AudioClip selectedClip;

	// Use this for initialization
	void Start () {
		clipList = Resources.LoadAll ("../../Audio/music");
		Debug.Log (clipList.Length);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
