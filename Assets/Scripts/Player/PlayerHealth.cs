using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public float startingHealth = 100f;
	public Slider healthSlider;
	public Image fillImage;
	public Color fullHealthColor = Color.green;
	public Color zeroHealthColor = Color.red;
	public float repelForce = 50f;
	[HideInInspector]
	public float currentHealth;

	private PlayerController pc;
	private Rigidbody rb;
	private Animator anim;
	private bool isDead;

	void Awake ()
	{
		pc = GetComponent <PlayerController> ();
		anim = GetComponent <Animator> ();
		rb = GetComponent <Rigidbody> ();
	}

	void OnEnable ()
	{
		currentHealth = startingHealth;
		isDead = false;
		
		SetHealthUI();
	}

	void SetHealthUI ()
	{
		healthSlider.value = currentHealth;
		
		fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, currentHealth / startingHealth);
	}

	void OnDeath ()
	{
		isDead = true;
		anim.SetBool(HashIDs.dieTrigger, true);
		healthSlider.gameObject.SetActive(false);
		//gameObject.SetActive (false);
	}

	void Repel (float damage)
	{
		Vector3 direction = -transform.forward + Vector3.up * 0.7f;
		//rb.AddForce(direction.normalized * damage * 0.7f, ForceMode.VelocityChange);
		rb.AddForce(direction.normalized * damage * repelForce);
	}

	public void TakeDamage (float amount)
	{
		if (pc.isBlockState)
			amount *= 0.5f;
		currentHealth -= amount;
		SetHealthUI ();


		if (currentHealth <= 0f && !isDead)
			OnDeath ();
		else
		{
			anim.SetTrigger(HashIDs.hitTrigger);
			Repel (amount);
		}
	}
}
