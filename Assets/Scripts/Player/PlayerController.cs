using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	[HideInInspector]
	public Rigidbody playerRigidbody;
	[HideInInspector]
	public Animator playerAnimator;
	[HideInInspector]
	public bool isBlocking;

	private bool isAttacking;

	// Use this for initialization
	void Awake () 
	{
		playerRigidbody = GetComponent <Rigidbody> ();
		playerAnimator = GetComponent <Animator> ();
		//hashIDs = GameObject.FindWithTag(Tags.gameController).GetComponent<HashIDs>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		isAttacking = (playerAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash == HashIDs.attackState);
	}

	public void Attack ()
	{
		if (!isAttacking)
			playerAnimator.SetTrigger(HashIDs.attackTrigger);
	}

	public void SetBlockingState (bool isButtonDown)
	{
		isBlocking = isButtonDown;
		playerAnimator.SetBool(HashIDs.isBlockingBool, isButtonDown);
	}


}
