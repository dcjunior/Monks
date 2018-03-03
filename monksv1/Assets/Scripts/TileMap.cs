using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

	public TileType[] tileTypes;

	public GameObject selectedUnit;

	public bool check=false;
	public float tilePos;
	Rigidbody2D RB;
	Animator Anim;

	float startTime;

	bool updatedPos;
	float fractLength;
	Vector3 targetPos = new Vector3 ();

	Vector3 startPos;
	Vector3 nextPos;

	int[] tiles;

	public int maxSpeed = 10;
	public int mapSize = 10;

	// Use this for initialization
	void Start () {

		//myRB = selectedUnit.GetComponentInChildren<Rigidbody2D> ();
		//myAnim = selectedUnit.GetComponentInChildren<Animator> ();
		generateMapData ();
		generateMapVisual ();
		
	}

	void Update(){

		/*
			myAnim.SetBool ("isWalkable", true);

			if (!updatedPos) {

				startPos = myRB.transform.position;
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

			myRB.transform.position = targetPos;
		}
			
			/*
		---------------------------------
			if (Vector3.Distance (myRB.transform.position, next) >= 0.05f) {
				CalculateHeading (next);
				SetHorizontalVel ();
				myAnim.SetBool ("isWalkable", true);

				myRB.transform.forward.Set (heading.x, heading.y, heading.z);
				myRB.AddForce (new Vector3 (maxSpeed * Time.deltaTime, 0f, 0f));
			} else {
				myRB.transform.position = next;
				myAnim.SetBool ("isWalkable", false);
			}
*/

	}

	void generateMapData(){
		
		tiles = new int[mapSize+2];

		/* LeftEnd = 0, RightEnd = 1, central = 2 */

		tiles [0] = 0;
		for (int x = 1; x < mapSize+1; x++) {
			tiles [x] = 2;
		}

		tiles [mapSize + 1] = 1;
	}
		
	
	void generateMapVisual(){
		int temp = -15;

		for(int x=0; x<mapSize+2 ; x++){

			TileType T = tileTypes[tiles[x]];
			GameObject c = (GameObject)Instantiate (T.tileVisualPrefab,new Vector3(temp,-9,10),Quaternion.identity);
			ClickableTile ct = c.GetComponent<ClickableTile>();
			ct.tileX = temp;
			ct.map = this;

			temp = temp + 6;
		}
	}

	public float moveSelectedUnitTo(float x){

		check = true;

		//tilePos = x;

		return x;
		/*
		Vector3 next = new Vector3 (x, -5.75f, 10.0f);

		if (Vector3.Distance (myRB.transform.position, next) >= 0.05f) {
			CalculateHeading (next);
			SetHorizontalVel ();
			myAnim.SetBool ("isWalkable", true);

			myRB.transform.forward.Set (heading.x, heading.y, heading.z);
			myRB.AddForce (new Vector3 (maxSpeed * Time.deltaTime, 0f, 0f));
		} else {
			myRB.transform.position = next;
			myAnim.SetBool ("isWalkable", false);
		}

*/
		//myAnim.SetBool ("isWalkable", true);
		//selectedUnit.transform.position = new Vector3 (x, -5.75f, 10.0f);

		//myRB.velocity = new Vector2 (myRB.velocity.x + maxSpeed, myRB.velocity.y);

		/*
		while (selectedUnit.transform.position != new Vector3 (x, -5.75f, 10.0f)) {
			myRB.velocity = new Vector2 (myRB.velocity.x + maxSpeed*100f, myRB.velocity.y);
			myAnim.SetBool ("isWalkable", true);
		}

		tempB = false;
*/

	}

	public void move(Animator myAnim, Rigidbody2D myRB){
	
		myAnim.SetBool ("isWalkable", true);

		if (!updatedPos) {

			startPos = myRB.transform.position;
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

		myRB.transform.position = targetPos;

	}

	/*
	void CalculateHeading (Vector3 target){
		//float w = myRB.rotation.w;
		heading = target - myRB.transform.position;
		heading.Normalize ();
		/*Debug.Log ("heading = "+ heading + facing);
		if (heading.x < 0 && facing) {
			myRB.rotation.Set (0f, 180f, 0f, w);
			facing = false;
		} else if (heading.x > 0 && !facing) {
			myRB.rotation.Set (0f, 0f, 0f, w);
			facing = true;
		}
	*/

	/*
	void SetHorizontalVel (){
		velocity = heading * maxSpeed;
	}
*/


	public void hit(Animator myAnim){
		//if (Input.GetKeyDown ("a"))
		myAnim.SetTrigger ("hit");
	}


	public void hurt(Animator myAnim){
		//if (Input.GetKeyDown ("space"))
		myAnim.SetTrigger ("hurt");
	}

	public void death(Animator myAnim){
		//bool check;
		//check = myAnim.GetBool ("death");
		//if (Input.GetKeyDown ("d"))
		//myAnim.SetBool ("death", !check);
		myAnim.SetTrigger("death");
		check = false;
		myAnim.SetBool ("isWalkable", false);
	}
}
