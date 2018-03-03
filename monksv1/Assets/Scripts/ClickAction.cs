using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour {


	
	// Update is called once per frame
	/*
	void Update () {
		if(Input.GetMouseButton(0)){
			Ray toMouse = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D rhInfo;
			rhInfo = Physics2D.Raycast (toMouse.origin,toMouse.direction,Mathf.Infinity);
			if (rhInfo) {
				//Debug.Log(rhInfo.collider.name+"--"+rhInfo.point);
			} else {
				Debug.Log ("Nothing");
			}
		}	
	}
	*/
}
