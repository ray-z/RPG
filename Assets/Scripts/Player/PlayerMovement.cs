using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour 
{
	public float moveSpeed = 10f;
	public float jumpSpeed = 5f;

	private Rigidbody rb;
	private Animator anim;
	private HashIDs hash;
	private bool isAttacking;
	private bool isGrounded;

	void Awake () 
	{
		rb = GetComponent <Rigidbody> ();
		anim = GetComponent <Animator> ();
		hash = GameObject.FindWithTag(Tags.gameController).GetComponent<HashIDs>();
	}
	
	void Update ()
	{
		isAttacking = (anim.GetCurrentAnimatorStateInfo(0).fullPathHash == hash.attackState);
		isGrounded = Physics.Raycast (transform.position, - Vector3.up, 0.1f);
	}
	
	void FixedUpdate () 
	{
		Vector3 moveInput = Vector3.zero;
		#if UNITY_STANDALONE || UNITY_WEBPLAYER
		moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
		moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		//moveInput = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0f, CrossPlatformInputManager.GetAxis("Vertical"));
		#endif

		moveInput = moveInput.normalized;	// avoid faster speed in diagonal
		if (moveInput != Vector3.zero)
		{
			Turn(moveInput);
			Move(moveInput);
		}
		anim.SetFloat(hash.speedFloat, moveInput.magnitude);
	}
	
	void Move (Vector3 moveInput)
	{

		Vector3 movement = moveInput * moveSpeed * Time.deltaTime;
		rb.MovePosition(rb.position + movement);
	}
	
	void Turn (Vector3 moveInput)
	{
		Quaternion rotation = Quaternion.LookRotation(moveInput);
		rb.MoveRotation(rotation);
	}

	public void Jump ()
	{
		if (isGrounded)
			rb.velocity += Vector3.up * jumpSpeed;
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
