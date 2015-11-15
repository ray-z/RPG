using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public GameObject playerObject;
	[HideInInspector]
	public PlayerHealth playerHealth;
	public float damage = 10f;
	public float timeBetweenAttacks = 0.5f;
	public float repelForce = 50f;

	private Rigidbody rb;
	private Animator anim;
	private bool isPlayerInRange;
	private float timer;

	void Awake ()
	{
		rb = GetComponent <Rigidbody> ();
		anim = GetComponent <Animator> ();
		playerHealth = playerObject.GetComponent <PlayerHealth> ();
	}

	void OnTriggerEnter (Collider other)
	{
		timer = 0;
		isPlayerInRange = (other.gameObject == playerObject);
	}

	void OnTriggerExit (Collider other)
	{
		isPlayerInRange = !(other.gameObject == playerObject);
	}

	void Update ()
	{
		timer += Time.deltaTime;

		if (isPlayerInRange && timer >= timeBetweenAttacks)
			Attack();

		Vector3 direction = -transform.forward + Vector3.up * 0.7f;
		Debug.DrawRay(transform.position, direction * 5f, Color.red);
	}

	void Attack ()
	{
		timer = 0f;
		anim.SetTrigger(HashIDs.attackTrigger);
		playerObject.transform.rotation = Quaternion.LookRotation(transform.position - playerObject.transform.position);
		playerHealth.TakeDamage (damage);
	}
	public void Repel (float damageTaken)
	{
		anim.SetTrigger(HashIDs.hitTrigger);
		//rb.AddForce(-transform.forward * damageTaken * repelForce);

		Vector3 direction = -transform.forward + Vector3.up * 0.7f;
		//rb.AddForce(direction.normalized * damage * 0.7f, ForceMode.VelocityChange);
		rb.AddForce(direction.normalized * damage * repelForce);
	}
}
