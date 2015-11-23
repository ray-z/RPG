using UnityEngine;
using System.Collections;

public class TestAlpha : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter ()
	{
		Debug.Log("hit here");
		Color c = gameObject.GetComponent<Renderer>().material.color;
		c.a = 0.1f;
		gameObject.GetComponent<Renderer>().material.color = c;
	}
}
