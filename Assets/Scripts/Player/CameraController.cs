using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public GameObject target;

	private Vector3 offset;
	// Use this for initialization
	void Start () 
	{
		offset = transform.position - target.transform.position;
	}
	
	void LateUpdate () 
	{
		Vector3 position = target.transform.position;
		position.y = 0;
		transform.position = position + offset;
	}
}
