using UnityEngine;
using System.Collections;
using System.Linq;

public class KeepAlive : MonoBehaviour {
	public bool keepAlive = false;
	public bool killDuplicate = false;

	void Start() {
		if (keepAlive) {
			DontDestroyOnLoad (gameObject);
		}
		if (killDuplicate) {
			if(GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1){
				Destroy (gameObject);
			}
		}
			
	}
}
