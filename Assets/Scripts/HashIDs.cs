using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour 
{
	public static int attackState = Animator.StringToHash("Base Layer.Attack");
	public static int speedFloat = Animator.StringToHash("Speed");
	public static int attackTrigger = Animator.StringToHash("Attack");
	public static int dieTrigger = Animator.StringToHash("Die"); 
	public static int isBlockingBool = Animator.StringToHash("IsBlocking"); 


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
