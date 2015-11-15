using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour 
{
	public static int attackState = Animator.StringToHash("Attack Layer.Attack");
	public static int hitStrongState0 = Animator.StringToHash("Base Layer.HitStrong");
	public static int hitStrongState1 = Animator.StringToHash("Attack Layer.HitStrong");
	public static int dieState = Animator.StringToHash("Base Layer.Die");


	public static int speedFloat = Animator.StringToHash("Speed");
	public static int attackTrigger = Animator.StringToHash("Attack");
	public static int dieTrigger = Animator.StringToHash("Die"); 
	public static int isBlockingBool = Animator.StringToHash("IsBlocking"); 
	public static int hitTrigger = Animator.StringToHash("Hit");


	/*
	void Awake ()
	{
		attackState = Animator.StringToHash("Base Layer.Attack");
		speedFloat = Animator.StringToHash("Speed");
		attackTrigger = Animator.StringToHash("Attack");
		isDeadBool = Animator.StringToHash("IsDead"); 
	}
	*/
}
