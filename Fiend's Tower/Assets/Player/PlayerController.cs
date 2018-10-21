using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float PlayerSpeed; // Float for movement speed

	public float PlayerJumping; // Float for jumping

	public bool isGrounded; //bool to check if player is grunded

	Animator PlayerAnims;

	public enum PlayerStates //Each animation state //getting reference to the character component 
	{
		Idle,
		Walk,
		Run,
		Jump,
		Attack,
		Death
	}

	public PlayerStates CurrentState;  // getting reference to PlayerStates abd setting it as a variable

	// Use this for initialization
	void Start () {


		PlayerAnims = GetComponent <Animator> (); //setting Animator variable to the component

		ChangeState (PlayerStates.Idle);

	} 

	public void ChangeState (PlayerStates newState) // Function to control when switching states
	{
		CurrentState = newState;

	}
	
	// Update is called once per frame
	void Update () {

		//Raycast for groundcheck
		RaycastHit hit;
		if (Physics.Raycast (gameObject.transform.position, -Vector3.up, out hit))
		{
			if (hit.transform.tag == "Ground")
			{
				isGrounded = true;
				Debug.Log ("Raycast hit ground");
			} 

			if (hit.transform.tag != "Ground")
			{
				isGrounded = false;
			}
		}


		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // Player movement to the left
		{
			transform.Translate (-PlayerSpeed * Time.deltaTime, 0f, 0f);
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // Player movement to the right
		{
			transform.Translate (PlayerSpeed * Time.deltaTime, 0f, 0f);
		}

		if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) // Player duck down
		{
			Debug.Log ("Player is Ducking");
		}

		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) // Player jumping
		{
			Debug.Log ("Player is jumping");
			transform.Translate (0f, PlayerJumping * Time.deltaTime, 0f);
			//transform.position += transform.up * PlayerJumping * Time.deltaTime;
		}


	}

	//Chararcter States (Placeholders for setting up animations in state machine for when we have sprites)
	IEnumerator IdleState ()
	{
		while (CurrentState == PlayerStates.Idle )
		{
			Debug.Log ("Idle");
			yield return null;
		}
	}

	IEnumerator WalkState ()
	{
		while (CurrentState == PlayerStates.Walk )
		{
			Debug.Log ("Walk");
			yield return null;
		}
	}

	IEnumerator RunState ()
	{
		while (CurrentState == PlayerStates.Run )
		{
			Debug.Log ("Run");
			yield return null;
		}
	}

	IEnumerator JumpState ()
	{
		while (CurrentState == PlayerStates.Jump )
		{
			Debug.Log ("Jump");
			yield return null;
		}
	}

	IEnumerator AttackState ()
	{
		while (CurrentState == PlayerStates.Attack )
		{
			Debug.Log ("Attack");
			yield return null;
		}
	}

	IEnumerator DeathState ()
	{
		while (CurrentState == PlayerStates.Death )
		{
			Debug.Log ("Death");
			yield return null;
		}
	}
}
