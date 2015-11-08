using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour 
{
	public float moveSpeed = 10f;
	public float turnSpeed = 5f;
	
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
		Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		moveInput = moveInput.normalized;
		if (moveInput != Vector3.zero)
		{
			Move(moveInput);
			Turn(moveInput);
		}
		anim.SetFloat(hash.speedFloat, moveInput.magnitude);
		
		
		//rb.MoveRotation(rb.rotation * turnRotation);
		
		
		/*
		if (moveValue < 0)	// move backwards
		{
			moveValue *= slowDownRate;
			turnValue *= slowDownRate;
		}

		if (turnValue != 0 || moveValue != 0)
		{
			Move(moveValue);
			Turn(turnValue);
		}
		anim.SetFloat(hash.speedFloat, Mathf.Abs(moveValue));
		*/
	}
	
	void Move (Vector3 moveInput)
	{
		Vector3 movement = moveInput * moveSpeed * Time.deltaTime;
		rb.MovePosition(rb.position + movement);
	}
	
	void Turn (Vector3 moveInput)
	{
		Quaternion rotation = Quaternion.LookRotation(moveInput);
		rb.rotation = Quaternion.Slerp(rb.rotation, rotation, Time.deltaTime * turnSpeed);
	}
	
	public void Attack ()
	{
		anim.SetTrigger(hash.attackTrigger);
	}
	
	/*
	 * Third person view with camera rotation
	//float moveValue = CrossPlatformInputManager.GetAxis("Vertical");
	void Move (float moveValue)
	{
		Vector3 movement = transform.forward * moveValue * moveSpeed * Time.deltaTime;
		rb.MovePosition(rb.position + movement);
	}

	//float turnValue = CrossPlatformInputManager.GetAxis("Horizontal");
	void Turn (float turnValue)
	{
		float turn = turnValue * turnSpeed * Time.deltaTime;
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
		rb.MoveRotation(rb.rotation * turnRotation);
	}
	*/
	
	
}
