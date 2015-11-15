using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	//public Transform targetTransform;

	EnemyController ec;
	Animator anim;
	NavMeshAgent nav;


	//Rigidbody enemyRigidbody;

	void Awake ()
	{
		//enemyRigidbody = GetComponent <Rigidbody> ();
		ec = GetComponent <EnemyController> ();
		anim = GetComponent <Animator> ();
		nav = GetComponent <NavMeshAgent> ();
	}

	void Update ()
	{
		if (ec.playerHealth.currentHealth > 0)
			Move ();
		else
			anim.SetFloat(HashIDs.speedFloat, 0f);
	}

	void Move ()
	{
		nav.SetDestination (ec.playerObject.transform.position);
		anim.SetFloat(HashIDs.speedFloat, nav.speed);
	}
}
