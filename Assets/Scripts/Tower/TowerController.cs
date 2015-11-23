using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour
{
	//Renderer baseRenderer;

	void Start () 
	{
	}



	void Update () 
	{
	}



	void OnMouseEnter ()
	{
		Debug.Log("hit here");

		SetAlpha (0.5f);
	}
	
	void OnMouseExit ()
	{
		//SetAlpha (1f);
	}

	void SetAlpha (float aValue)
	{
		foreach (Transform child in transform)
		{
			Color c = child.gameObject.GetComponent<Renderer>().material.color;
			c.a = aValue;
			child.gameObject.GetComponent<Renderer>().material.color = c;
		}
	}
}
