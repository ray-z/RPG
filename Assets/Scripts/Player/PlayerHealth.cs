using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public float startingHealth = 100f;
	public Slider healthSlider;
	public Image fillImage;
	public Color fullHealthColor = Color.green;
	public Color zeroHealthColor = Color.red;

	private PlayerController pc;
	private float currentHealth;
	private bool isDead;

	private void Start ()
	{
		pc = GetComponent <PlayerController> ();
	}

	private void OnEnable ()
	{
		currentHealth = startingHealth;
		isDead = false;
		
		SetHealthUI();
	}

	private void SetHealthUI ()
	{
		healthSlider.value = currentHealth;
		
		fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, currentHealth / startingHealth);
	}

	private void OnDeath ()
	{
		isDead = true;
		pc.playerAnimator.SetBool(HashIDs.dieTrigger, true);
		healthSlider.gameObject.SetActive(false);
		//gameObject.SetActive (false);
	}

	public void TakeDamage (float amount)
	{
		currentHealth -= amount;
		SetHealthUI ();
		
		if (currentHealth <= 0f && !isDead)
			OnDeath ();
		else
		{
			if (!pc.isHitState)
				pc.playerAnimator.SetTrigger(HashIDs.hitTrigger);
		}
	}
}
