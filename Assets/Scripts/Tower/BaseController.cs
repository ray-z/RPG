using UnityEngine;
using System.Collections;

public class BaseController : MonoBehaviour {

	CameraController cameraController;
	// Use this for initialization
	void Start () 
	{
		cameraController = Camera.main.GetComponent<CameraController>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown ()
	{
		//Debug.Log ("hit here");
		//Camera.main.transform.position = transform.position;
		cameraController.newTargetView(transform);
	}
}
