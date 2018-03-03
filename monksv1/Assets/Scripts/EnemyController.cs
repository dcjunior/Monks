using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	GameObject gb;
	Animator myAnim;
	Rigidbody2D myRb;
	TileMap map;
	float tilePos;
	ClickableTile ct;




	//public float tilePos;
	bool check=false;

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
		if (Input.GetKeyDown ("z"))
			hurt ();

		if (Input.GetKeyDown ("x"))
			hit ();

		if (Input.GetKeyDown ("c"))
			death ();

		if (Input.GetMouseButton (1)) {

			Ray toMouse = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D rhInfo;
			rhInfo = Physics2D.Raycast (toMouse.origin, toMouse.direction, Mathf.Infinity);

			if (rhInfo.collider.CompareTag("tile")) {
				gb = rhInfo.collider.gameObject;
				ct = gb.GetComponent<ClickableTile> ();
				tilePos = ct.tileX;
				check = true;
				Debug.Log (rhInfo.collider.name + " tilex " + ct.tileX);
			}
			else {
				Debug.Log ("Nothing");
			}
		}

		if (check)
			move ();


	}

	public void move(){

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
