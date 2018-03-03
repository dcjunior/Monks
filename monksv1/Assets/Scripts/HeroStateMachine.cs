using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStateMachine : MonoBehaviour {

	public BaseHero hero;

	public enum TurnState
	{
		PROCESSING,
		ADDTOLIST,
		WAITING,
		SELECTING,
		ACTION,
		DEAD
	}

	public TurnState currentState;

	private float currCooldown = 0f;
	private float maxCooldown = 5f;

	public Image ProgressBar;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentState)
		{
		case(TurnState.PROCESSING):
			updateProgressBar ();
			break;

		case(TurnState.SELECTING):
			break;

		case(TurnState.ACTION):
			break;

		case(TurnState.ADDTOLIST):
			break;

		case(TurnState.DEAD):
			break;
		
		case(TurnState.WAITING):
			break;
		}
	}

	void updateProgressBar(){
		currCooldown = currCooldown + Time.deltaTime;
		float calcCooldonw = currCooldown / maxCooldown;
		ProgressBar.transform.localScale = new Vector3 (Mathf.Clamp (calcCooldonw, 0, 1), ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);
		if (currCooldown >= maxCooldown) 
		{
			currentState = TurnState.ADDTOLIST;
		}
			
	}
}
