using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


	private float currCooldown = 0f;
	private float maxCooldown = 5f;

	public Image ProgressBar;


	void updateProgressBar(){
		currCooldown = currCooldown + Time.deltaTime;
		float calcCooldonw = currCooldown / maxCooldown;
		ProgressBar.transform.localScale = new Vector3 (Mathf.Clamp (calcCooldonw, 0, 1), ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);
		if (currCooldown >= maxCooldown)
			currCooldown = 0f;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		updateProgressBar ();
	}
}
