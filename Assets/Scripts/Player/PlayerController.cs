using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float attackRange = 2f;
	public float damage = 10f;
	[HideInInspector]
	public bool isBlockState;
	[HideInInspector]
	public bool isHitState;
	[HideInInspector]
	public bool isDieState;

	//private Rigidbody rb;
	private Animator anim;
	private bool isAttacking;
	private RaycastHit attackHit;   
	private Ray attackRay;
	private int enemyMask;
	private Vector3 offsetPos;

	void Awake () 
	{
		//rb = GetComponent <Rigidbody> ();
		anim = GetComponent <Animator> ();
		enemyMask = LayerMask.GetMask ("Enemy");
		offsetPos = new Vector3 (0f, 0.5f, 0f);

	}
	
	void Update () 
	{
		int baseState = anim.GetCurrentAnimatorStateInfo(0).fullPathHash;
		int attackState = anim.GetCurrentAnimatorStateInfo(1).fullPathHash;
		isAttacking = (attackState == HashIDs.attackState);
		isHitState = (baseState == HashIDs.hitStrongState0 || attackState == HashIDs.hitStrongState1);
		isDieState = (baseState == HashIDs.dieState);
	}


	public void Attack ()
	{
		if (isAttacking)
			return;

		anim.SetTrigger(HashIDs.attackTrigger);

		if(Physics.Raycast (transform.position + offsetPos, transform.forward, out attackHit, 100f, enemyMask))
		{
			EnemyController ec = attackHit.collider.GetComponent <EnemyController> ();
			if (ec != null)
			{
				ec.Repel(damage);
			}
		}

	}

	public void SetBlockingState (bool isButtonDown)
	{
		isBlockState = isButtonDown;
		anim.SetBool(HashIDs.isBlockingBool, isButtonDown);
	}
}
