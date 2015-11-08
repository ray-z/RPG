using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour 
{
	public float moveSpeed = 10f;
	public float turnSpeed = 180f;
	public float slowDownRate = 0.5f;

	private Rigidbody rb;
	private Animator anim;
	private HashIDs hash;

	void Awake () 
	{
		rb = GetComponent <Rigidbody> ();
		anim = GetComponent <Animator> ();
		hash = GameObject.FindWithTag(Tags.gameController).GetComponent<HashIDs>();
	}

	void Update ()
	{
	}

	void FixedUpdate () 
	{
		float turnValue = CrossPlatformInputManager.GetAxis("Horizontal");	//Input.GetAxis("Horizontal");
		float moveValue = CrossPlatformInputManager.GetAxis("Vertical");	//Input.GetAxis("Vertical");
		if (moveValue < 0)
		{
			moveValue *= slowDownRate;
			turnValue *= slowDownRate;
		}


		if (turnValue != 0 || moveValue != 0)
		{
			Move(moveValue);
			Turn(turnValue);
		}
		anim.SetFloat(hash.speedFloat, Mathf.Max(0.2f, Mathf.Abs(moveValue)));

		/*
		// Prevent animation when rotating
		if (Mathf.Abs(moveValue)>= 0.1f)
			anim.SetBool(hash.walkingBool, true);
		else
			anim.SetBool(hash.walkingBool, false);
		*/
	}

	void Move (float moveValue)
	{
		Vector3 movement = transform.forward * moveValue * moveSpeed * Time.deltaTime;
		rb.MovePosition(rb.position + movement);
	}

	void Turn (float turnValue)
	{
		float turn = turnValue * turnSpeed * Time.deltaTime;
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
		rb.MoveRotation(rb.rotation * turnRotation);
	}
}
