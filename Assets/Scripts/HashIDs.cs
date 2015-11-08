using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour 
{
	public int walkingBool;
	public int multiplierFloat;
	public int speedFloat;

	void Awake ()
	{
		walkingBool = Animator.StringToHash("Walking");
		multiplierFloat = Animator.StringToHash("Multiplier");
		speedFloat = Animator.StringToHash("Speed");
	}
}
