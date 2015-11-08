using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour 
{
	public int speedFloat;
	public int attackTrigger;

	void Awake ()
	{
		speedFloat = Animator.StringToHash("Speed");
		attackTrigger = Animator.StringToHash("Attack");
	}
}
