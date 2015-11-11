using UnityEngine;
using System.Collections;

public class UIDirectionControl : MonoBehaviour 
{
	public bool isRelativeRotation = true;

	private Quaternion relativeRotation;

	// Use this for initialization
	void Start ()
	{
		relativeRotation = transform.parent.localRotation;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isRelativeRotation)
			transform.rotation = relativeRotation;
	}
}
