using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

	//public GameObject Map;
	Animator myAnim;
	Rigidbody2D myRb;
	float tilePos;
	ClickableTile ct;
	GameObject gb;



	//public float tilePos;
	bool check = false;

	float startTime;

	bool updatedPos;
	float fractLength;

	Vector3 targetPos;
	Vector3 startPos;
	Vector3 nextPos;

	public int maxSpeed = 5;


	void Start(){
		myAnim = GetComponent<Animator> ();
		myRb = GetComponent<Rigidbody2D> ();
	}


	void Update(){

		if (Input.GetKeyDown ("a"))
			hurt ();

		if (Input.GetKeyDown ("space"))
			hit ();

		if (Input.GetKeyDown ("d"))
			death ();

		if (Input.GetMouseButton (0)) {

			Ray toMouse = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D rhInfo;
			rhInfo = Physics2D.Raycast (toMouse.origin, toMouse.direction);

			if (rhInfo.collider.CompareTag("tile")) {
				gb = rhInfo.collider.gameObject;
				ct = gb.GetComponent<ClickableTile> ();
				tilePos = ct.tileX;
				check = true;
				Debug.Log (rhInfo.collider.name + " tilex " + ct.tileX);
				//Debug.DrawRay (toMouse.origin, toMouse.direction);
			}
			else {
				Debug.Log ("Nothing");
			}
		}

		if (check)
			move ();
		

	}

/*
	// Use this for initialization
	void Start () {

		myRb = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		
	}

	*/

	void move(){

		myAnim.SetBool ("isWalkable", true);

		if (!updatedPos) {

			startPos = myRb.transform.position;
			nextPos = new Vector3 (tilePos, -5.75f, 10.0f);

			fractLength = Vector3.Distance (startPos, nextPos);
			startTime = Time.time;
			updatedPos = true;
		}

		float distCover = (Time.time - startTime) * maxSpeed;

		if (fractLength == 0) {
			fractLength = 0.1f;
			check = false;
			myAnim.SetBool ("isWalkable", false);
		}
		float fracJourney = distCover / fractLength;
		if (fracJourney > 1)
			updatedPos = false;

		targetPos = Vector3.Lerp (startPos, nextPos, fracJourney);
		Debug.Log ("Location:" + targetPos + " " + nextPos);

		myRb.transform.position = targetPos;


		Debug.Log (check);
	}


	void hit(){
		//if (Input.GetKeyDown ("a"))
		myAnim.SetTrigger ("hit");
	}


	void hurt(){
		//if (Input.GetKeyDown ("space"))
		myAnim.SetTrigger ("hurt");
	}

	void death(){
		//bool check;
		//check = myAnim.GetBool ("death");
		//if (Input.GetKeyDown ("d"))
		//myAnim.SetBool ("death", !check);
		myAnim.SetTrigger("death");
	}
}
	