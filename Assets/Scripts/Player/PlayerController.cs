using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	private Rigidbody rb;
	private Animator anim;
	private HashIDs hash;
	private bool isAttacking;

	// Use this for initialization
	void Awake () 
	{
		rb = GetComponent <Rigidbody> ();
		anim = GetComponent <Animator> ();
		hash = GameObject.FindWithTag(Tags.gameController).GetComponent<HashIDs>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		isAttacking = (anim.GetCurrentAnimatorStateInfo(0).fullPathHash == hash.attackState);
	}

	public void Attack ()
	{
		if (!isAttacking)
			anim.SetTrigger(hash.attackTrigger);
	}


}
