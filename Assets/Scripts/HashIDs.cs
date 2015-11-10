using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour 
{
	public int attackState;
	public int speedFloat;
	public int attackTrigger;

	void Awake ()
	{
		attackState = Animator.StringToHash("Base Layer.Attack");
		speedFloat = Animator.StringToHash("Speed");
		attackTrigger = Animator.StringToHash("Attack");
	}
}
