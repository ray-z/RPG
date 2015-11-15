using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	[HideInInspector]
	public Rigidbody playerRigidbody;
	[HideInInspector]
	public Animator playerAnimator;
	[HideInInspector]
	public bool isBlockState;
	[HideInInspector]
	public bool isHitState;
	[HideInInspector]
	public bool isDieState;

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
		int baseState = playerAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash;
		int attackState = playerAnimator.GetCurrentAnimatorStateInfo(1).fullPathHash;
		isAttacking = (attackState == HashIDs.attackState);
		isHitState = (baseState == HashIDs.hitStrongState0 || attackState == HashIDs.hitStrongState1);
		isDieState = (baseState == HashIDs.dieState);
	}

	public void Attack ()
	{
		if (!isAttacking)
			playerAnimator.SetTrigger(HashIDs.attackTrigger);
	}

	public void SetBlockingState (bool isButtonDown)
	{
		isBlockState = isButtonDown;
		playerAnimator.SetBool(HashIDs.isBlockingBool, isButtonDown);
	}


}
