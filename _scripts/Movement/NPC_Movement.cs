using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC_Movement : MonoBehaviour {

	Rigidbody2D rbody;
	Animator anim;
	public int speed = 1;
	public int mode = 0;
	public float range = 0.0f;

	public int walkTimeMin = 20;
	public int walkTimeMax = 50;
	public int waitTimeMin = 10;
	public int waitTimeMax = 30;
	public float newWaitTime = 0.0f;
	public List<Transform> targets;

	public bool thisCanMove = true;
	private bool isWaiting = true;
	private Vector3 newDirection;
	private float newWalkTime = 0.0f;
	private int counter = 0;

	private GameObject playerPos;

	private float distance;
	private Vector3 heading;
	private Vector3 direction; // This is now the normalized direction.

	/*
	 * 0 - Stand still
	 * 1 - random
	 * 2 - follow
	 * 3 - flee
	 * 4 - path
	 * 
	 */

	void Start () {
		rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		playerPos = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
		if (GameManager.canMove) {
			thisCanMove = true;
		}

		if (thisCanMove) {

			distance = Vector2.Distance (this.transform.position, playerPos.transform.position);
			heading = this.transform.position - playerPos.transform.position;
			direction = heading / distance; // This is now the normalized direction.

			// Still
			if (mode == 0) {


			// RANDOM
			} else if (mode == 1) {
				if (!isWaiting) {
					if (newWalkTime <= 0) {
						randomDirection ();
					} else {
						rbody.MovePosition (rbody.transform.position + newDirection * Time.deltaTime * speed);
						newWalkTime -= Time.deltaTime;
					}
				} else {
					if (newWaitTime <= 0) {
						randomDirection ();
					} else {
						newWaitTime -= Time.deltaTime;
					}

				}
		
			// FOLLOW
			} else if (mode == 2) {
				var getDistance = Vector2.Distance (rbody.transform.position, playerPos.transform.position);
				if (getDistance > range) {
					anim.SetBool ("isWalking", true);
					rbody.transform.position = Vector2.MoveTowards (rbody.transform.position, playerPos.transform.position, Time.deltaTime * speed);
					anim.SetFloat ("Input_x", direction.x * -1);
					anim.SetFloat ("Input_y", direction.y * -1);
				} else {
					anim.SetBool ("isWalking", false);
				}
				
				// Flee
			} else if (mode == 3) {
				var getDistance = Vector2.Distance (rbody.transform.position, playerPos.transform.position);
				if (getDistance < range) {
					anim.SetBool ("isWalking", true);
					rbody.transform.position = Vector2.MoveTowards (rbody.transform.position, playerPos.transform.position, (Time.deltaTime * speed) * -1);
					anim.SetFloat ("Input_x", direction.x);
					anim.SetFloat ("Input_y", direction.y);
				} else {
					anim.SetBool ("isWalking", false);
				}
				
				
			// PATH
			} else if (mode == 4) {
				distance = Vector2.Distance (this.transform.position, targets [counter].position);
				heading = this.transform.position - targets [counter].position;
				direction = heading / distance; // This is now the normalized direction.


				if (!isWaiting) {
					if (newWalkTime <= 0) {
						checkPath (direction);
					} else {
						rbody.transform.position = Vector2.MoveTowards (rbody.transform.position, targets [counter].position, Time.deltaTime * speed);
						newWalkTime -= Time.deltaTime;
					}
				} else {
					if (newWaitTime <= 0) {
						checkPath (direction);
					} else {
						newWaitTime -= Time.deltaTime;
					}

				}
			}
		}

		//This needs work.
		if (!thisCanMove) {
			anim.SetFloat ("Input_x", direction.x*-1);
			anim.SetFloat ("Input_y", direction.y*-1);
		}
	
	}

	void randomDirection(){
		isWaiting = !isWaiting;
		if (isWaiting) {
			anim.SetBool ("isWalking", false);
			newWaitTime = Random.Range (waitTimeMin, waitTimeMax);
		} else {
			anim.SetBool ("isWalking", true);
			newDirection = new Vector3 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f),0.0f);
			newWalkTime = Random.Range (walkTimeMin, walkTimeMax);
			anim.SetFloat ("Input_x", newDirection.x);
			anim.SetFloat ("Input_y", newDirection.y);
		}
	}

	void checkPath(Vector2 dir){
		isWaiting = !isWaiting;
		if (isWaiting) {
			anim.SetBool ("isWalking", false);
			newWaitTime = Random.Range (waitTimeMin, waitTimeMax);
			counter++;
			if (counter == targets.Count) {
				counter = 0;
			}
		} else {
			anim.SetBool ("isWalking", true);
			newWalkTime = Random.Range (walkTimeMin, walkTimeMax);
			anim.SetFloat ("Input_x", dir.x*-1);
			anim.SetFloat ("Input_y", dir.y*-1);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		newWalkTime = 0.0f;
	}
		
}
