using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public Transform playerTransform;
	public float cameraUp = 2f;

	Vector3 playerOffset;

	Vector3 targetPosition;
	Vector3 targetOffset;

	bool isTransforming;

	CameraMode cameraMode;

	enum CameraMode
	{
		FollowPlayer,
		ToTarget,
		ToPlayer
	}

	// Use this for initialization
	void Start () 
	{
		transform.LookAt(playerTransform.position + playerTransform.up * cameraUp);
		playerOffset = transform.position - playerTransform.position;
		isTransforming = false;
	}
	
	void LateUpdate () 
	{
		/*
		if (isTransforming)
		{
			MoveToNewTarget ();
		}
		else
		{
			FollowPlayer ();
		}
		*/

		switch (cameraMode)
		{
		case CameraMode.FollowPlayer:
			FollowPlayer ();
			break;
		case CameraMode.ToTarget:
			MoveToNewTarget ();
			break;
		case CameraMode.ToPlayer:
			MoveToPlayer ();
			break;
		default:
			Debug.Log("Unsupported camera mode.");
			break;
		}

	}

	void FollowPlayer ()
	{
		transform.position = playerTransform.position + playerOffset;
	}

	void MoveToNewTarget ()
	{
		Vector3 direction = (targetPosition - transform.position).normalized;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
		transform.position = Vector3.Lerp(transform.position, targetPosition + targetOffset, Time.deltaTime);
	}

	void MoveToPlayer ()
	{
		Vector3 direction = (playerTransform.position + playerTransform.up * cameraUp - transform.position).normalized;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
		transform.position = Vector3.Lerp(transform.position, playerTransform.position + playerOffset, Time.deltaTime);

		float distance = Vector3.Distance(transform.position, playerTransform.position + playerOffset);
		float angle = Vector3.Angle(transform.position, playerTransform.position);
		Debug.Log(angle);
		if (distance < 0.5f && angle < 1.5f)
		{
			cameraMode = CameraMode.FollowPlayer;
			//transform.LookAt(playerTransform.position + playerTransform.up * cameraUp);
		}
	}

	public void PlayerView ()
	{
		cameraMode = CameraMode.ToPlayer;
	}

	public void newTargetView (Transform newTransform)
	{
		cameraMode = CameraMode.ToTarget;
		targetPosition = newTransform.position + Vector3.up * 2;
		targetOffset = newTransform.forward * 3 + newTransform.up * 3 + newTransform.right * 3;
		isTransforming = true;
	}







}
