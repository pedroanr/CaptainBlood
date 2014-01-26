﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Character_Falling : FSMState {
	
	[System.NonSerialized]
	public PlayerController Parent;
	
	// Use this for initialization
	public override void OnEnter () {
		Debug.Log( "Entered " + this );
	}
	
	// Use this for initialization
	public override void OnExit () {
		Debug.Log( "Exiting " + this );
	}
	
	public override void OnUpdate(){
		//	Debug.Log( "UPDATING FALL!!" );
		
		if (Parent.rigidbody2D.velocity.y <= 0) {
			// Are we still in the air? If not go idle
			if (Parent.LineCasting ())
			{
				Parent.GoToState (Parent.s_idle);
			}
		}

		// interact
		if (Input.GetButtonDown (Parent.InteractInput())){
			Parent.CheckInteraction();
		}

		//retrieve axis info
		Parent.horizAxis = Input.GetAxis(Parent.HorizInput());
	//	if (Parent.grounded) {
	//		Parent.GoToState (Parent.s_idle);
	//	}
		Parent.vertAxis = Input.GetAxis(Parent.VertInput());
		if (Parent.canLadder && (Mathf.Abs (Parent.vertAxis) > 0.1f)) 
		{
			Parent.GoToState(Parent.s_ladder);
		}
	}
	
	
}
